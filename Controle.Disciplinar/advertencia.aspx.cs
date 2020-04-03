using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class advertencia : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void txtRE_TextChanged(object sender, EventArgs e)
        {
            if (txtRE.Text == "")
            {
                GridView1.Visible = false;
            }
            buscaColaborador(txtRE.Text);
            ListarAdvertencias();
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
            }
            con.FecharCon();

        }
        private void ListarAdvertencias()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "select advertencia.dataOcorrencia, item.item,subitem.subitem, artigo.artigo, inciso.inciso, infracoes.medida, advertencia.observacoes  from infracoes inner join item on infracoes.itemID = item.itemID left join subitem on infracoes.subitemid = subitem.subitemid left join inciso on infracoes.incisoID = inciso.incisoID left join artigo on infracoes.itemID = artigo.artigoID inner join advertencia on infracoes.advertenciaID = advertencia.advertenciaID where advertencia.idColaborador = @idColaborador";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", Convert.ToInt32(txtidColaborador.Text));
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
                Label1.Visible = true;
                Label1.Text = "Não foram encontrados registros para o Colaborador Informado";
            // con.FecharCon();

        }
    }
}