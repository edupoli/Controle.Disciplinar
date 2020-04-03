using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Controle.Disciplinar
{
    public partial class advertencia1 : System.Web.UI.Page
    {
        string advertenciaID;
        string colaborador;
        long id;
        string login;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            txtAdvertenciaID.Text = advertenciaID;
            //login = Session["usuario"].ToString();
            if (advertenciaID != null)
            {
                Listar();

            }
            if (Session["usuario"] != null)
            {
                textUsuario.Text = Session["nome"].ToString();
            }

        }
        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,advertencia.observacoes,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador WHERE advertencia.advertenciaID=@advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtRE.Text = dt.Rows[0][4].ToString();
                txtNome.Text = dt.Rows[0][3].ToString();
                txtDataAdmissao.Text = dt.Rows[0][5].ToString();
                dataOcorrencia.Text = dt.Rows[0][1].ToString();
                
            }

            con.FecharCon();
        }
        private void buscaColaborador(string re)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable ds = new DataTable();
            sql = "SELECT * FROM colaborador WHERE re=@re";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@re", txtRE.Text);
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Rows.Count == 0)
            {
                txtRE.Text = string.Empty;
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorColaborador();", true);
            }
            else
            {
                txtNome.Text = ds.Rows[0][1].ToString();
                txtDataAdmissao.Text = ds.Rows[0][3].ToString();
                txtidColaborador.Text = ds.Rows[0][0].ToString();
                colaborador = txtNome.Text;
            }
            con.FecharCon();

        }

        protected void txtRE_TextChanged(object sender, EventArgs e)
        {
            buscaColaborador(txtRE.Text);
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtRE.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroPreencColaborador();", true);
            }
            else
            if (dataOcorrencia.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorData();", true);
            }
            else
                Salvar();
        }
        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO advertencia(idColaborador,dataOcorrencia,observacoes,usuario) VALUES(@idColaborador,@dataOcorrencia,@observacoes,@usuario)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", txtidColaborador.Text);
            cmd.Parameters.AddWithValue("@dataOcorrencia", Convert.ToDateTime(dataOcorrencia.Text));
            cmd.Parameters.AddWithValue("@observacoes", txtobs.Text);
            cmd.Parameters.AddWithValue("@usuario", textUsuario.Text);
            cmd.ExecuteNonQuery();
            id = cmd.LastInsertedId;
            ultimoID.Text = Convert.ToString(cmd.LastInsertedId);
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);


            //Label1.Text = "Dados Inseridos com Sucesso!";

            //con.FecharCon();
            advertenciaID = ultimoID.Text;
            Response.Redirect("addpunir.aspx?advertenciaID=" + advertenciaID + "&colaborador=" + txtNome.Text );
            
            return;
            

        }
    }

}