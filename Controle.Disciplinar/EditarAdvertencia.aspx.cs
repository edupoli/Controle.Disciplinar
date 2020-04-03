using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Controle.Disciplinar
{
    public partial class EditarAdvertencia : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        string advertenciaID;
        string colaborador;
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            txtAdvertenciaID.Text = advertenciaID;
            if (!this.IsPostBack)
            {
                Listar();
            }

        }

        protected void txtRE_TextChanged(object sender, EventArgs e)
        {
            buscaColaborador(txtRE.Text);
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
        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT advertencia.advertenciaID, advertencia.idColaborador, advertencia.dataOcorrencia,advertencia.observacoes,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador WHERE advertencia.advertenciaID=@advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtRE.Text = dt.Rows[0][5].ToString();
                txtNome.Text = dt.Rows[0][4].ToString();
                txtDataAdmissao.Text = dt.Rows[0][6].ToString();
                dataOcorrencia.Text = dt.Rows[0][2].ToString();
                txtobs.Text = dt.Rows[0][3].ToString();
                txtidColaborador.Text = dt.Rows[0][1].ToString();

            }

            con.FecharCon();
        }
        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE advertencia SET idColaborador=@idColaborador,dataOcorrencia=@dataOcorrencia,observacoes=@observacoes where advertenciaID=@advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            cmd.Parameters.AddWithValue("@idColaborador", txtidColaborador.Text);
            cmd.Parameters.AddWithValue("@dataOcorrencia", Convert.ToDateTime(dataOcorrencia.Text));
            cmd.Parameters.AddWithValue("@observacoes", txtobs.Text);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);


            //Label1.Text = "Dados Inseridos com Sucesso!";

            //con.FecharCon();


            return;


        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dataOcorrencia.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorData();", true);
            }
            else
            {
                Salvar();
            }
        }
    }
}