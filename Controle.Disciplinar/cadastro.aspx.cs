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
    public partial class Contact : Page
    {
        int idColaborador;
        string login;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = (string)Session["usuario"];
            if (usuario == null)
            {
                Response.Redirect("expirou.aspx");
            }
            else
            {
                login = Session["usuario"].ToString();
                grid.Visible = false;
                painelErroGrid.Visible = false;
                Listar();
            }
            
        }
        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM colaborador ORDER BY nome";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grid.Visible = true;
                grid.DataSource = dt;
                grid.DataBind();
            }
            else
            {
                grid.Visible = false;
                painelErroGrid.Visible = true;
                gridMensagemErro.Text = "Não existem Lançamentos Cadastrados!";
            }
            con.FecharCon();

        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
                idColaborador = Convert.ToInt32((sender as Button).CommandArgument);
                Response.Redirect("addColaborador.aspx?idColaborador=" + idColaborador);

        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
                idColaborador = Convert.ToInt32((sender as Button).CommandArgument);
                Excluir();
                Listar();

        }
        private void Excluir()
        {

            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "DELETE FROM colaborador WHERE idColaborador =@idColaborador";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", idColaborador);

            cmd.ExecuteNonQuery();

            painelErroGrid.Visible = true;
            gridMensagemErro.Text = "Lançamento excluido com Sucesso!";
            return;
            con.FecharCon();
            Response.Redirect("pabx.aspx");
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
                Response.Redirect("relatorio.aspx");

        }
    }
}