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
    public partial class addUser : System.Web.UI.Page
    {
        string id;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            painelErro.Visible = false;
            painelOk.Visible = false;
            id = Request.QueryString["id"];
            txtuserid.Text = id;
            if (id != "" && txtNome.Text == "")
            {
                ListarDadosEditar();
            }

        }
        private void ListarDadosEditar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT * FROM usuarios WHERE userId=@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtLogin.Text = dt.Rows[0][2].ToString();
                txtSenha.Text = dt.Rows[0][3].ToString();
                txtNome.Text = dt.Rows[0][1].ToString();


            }

            con.FecharCon();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorNome();", true);
                txtNome.Focus();
                return;
            }
            if (txtLogin.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "erroLogin();", true);
                txtLogin.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorSenha();", true);
                txtSenha.Focus();
                return;
            }
            if (txtConfirmaSenha.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorConfirmarSenha();", true);
                txtConfirmaSenha.Focus();
                return;
            }
            if (txtSenha.Text != txtConfirmaSenha.Text)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorSenhaIguais();", true);
                txtConfirmaSenha.Focus();
                return;
            }
            
            if (id == null && txtNome.Text != "")
            {
                Salvar();
            }
            else
            {
                Editar();
            }
        }

        private void Editar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE usuarios SET nome=@nome,login=@login,senha=@senha WHERE userId =@id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@login", txtLogin.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

            cmd.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucessoAlterado();", true);
            con.FecharCon();
            return;
            Response.Redirect("usuarios.aspx");

        }

        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO usuarios (nome,login,senha) VALUES(@nome,@login,@senha)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@login", txtLogin.Text);
            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

            cmd.ExecuteNonQuery();

            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);

            con.FecharCon();
            txtNome.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
            return;
            Response.Redirect("usuarios.aspx");


        }
    }
}