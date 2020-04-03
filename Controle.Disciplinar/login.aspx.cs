using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Controle.Disciplinar
{
    public partial class login : System.Web.UI.Page
    {
        Object obj;
        Conexao con = new Conexao();
        public string usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.AbrirCon();
            painelMensagemErro.Visible = false;
        }

        protected void bntLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                painelMensagemErro.Visible = true;
                MensagemErro.Text = "Digite o Login de Usuario para acessar o sistema!";
            }
            else if (txtPassword.Text == "")
            {
                painelMensagemErro.Visible = true;
                MensagemErro.Text = "Digite a senha de Usuario para acessar o sistema!";
            }
            else
            {
                string sql;
                string query;
                MySqlCommand cmd;
                MySqlCommand result;
                con.AbrirCon();
                sql = "SELECT count(*) FROM usuarios WHERE login=@login and senha=@senha";
                query = "SELECT * FROM usuarios WHERE login=@login and senha=@senha";
                cmd = new MySqlCommand(sql, con.con);
                result = new MySqlCommand(query, con.con);
                cmd.CommandType = CommandType.Text;
                result.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@login", txtUsuario.Text);
                result.Parameters.AddWithValue("@login", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@senha", txtPassword.Text);
                result.Parameters.AddWithValue("@senha", txtPassword.Text);
                obj = cmd.ExecuteScalar();
                string nome = "";
                string perfil = "";
                if (Convert.ToInt32(obj) != 0)
                {
                    string user = txtUsuario.Text;
                    Session["usuario"] = user;

                    MySqlDataReader dr = result.ExecuteReader();
                    while (dr.Read())
                    {
                        nome += dr["nome"].ToString();
                        Session["nome"] = nome;
                        perfil += dr["perfil"].ToString();
                        Session["perfil"] = perfil;
                        Session.Timeout = 1440;
                        Response.Redirect("historico.aspx");
                    }


                }
                else
                {
                    painelMensagemErro.Visible = true;
                    MensagemErro.Text = "Usuario ou Senha Inválidos!";

                }
            }
        }
    }

    internal class usuarios
    {
        public string nome { get; set; }
    }
}