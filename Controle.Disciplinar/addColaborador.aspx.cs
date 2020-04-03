using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Controle.Disciplinar
{
    public partial class addColaborador : System.Web.UI.Page
    {
        //variavel criada para receber o valor do ID da pagina 
        string idColaborador;
        string login;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            painelErro.Visible = false;
            painelOk.Visible = false;
            login = Session["usuario"].ToString();
            idColaborador = Request.QueryString["idColaborador"];
            txtidColaborador.Text = idColaborador;

            if (idColaborador != "" && txtNome.Text == "")
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
            sql = "SELECT * FROM colaborador WHERE idColaborador=@idColaborador";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", idColaborador);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtNome.Text = dt.Rows[0][1].ToString();
                txtRE.Text = dt.Rows[0][2].ToString();
                txtDataAdmissao.Text = dt.Rows[0][3].ToString();
                txtobs.Text = dt.Rows[0][4].ToString();
            }

            con.FecharCon();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                painelErro.Visible = true;
                lblMensagemErro.Text = "Favor Preencher o Nome do Colaborador!";
                txtNome.Focus();
                return;

            }
            if (txtRE.Text == "")
            {
                painelErro.Visible = true;
                lblMensagemErro.Text = "Favor Preencher o numero do RE";
                txtRE.Focus();
                return;

            }
            decimal numero;
            if (!decimal.TryParse(txtRE.Text, out numero))
            {
                painelErro.Visible = true;
                lblMensagemErro.Text = "Insira apenas numeros no campo RE";
                txtRE.Focus();
                return;

            }
            if (txtDataAdmissao.Text == "")
            {
                painelErro.Visible = true;
                lblMensagemErro.Text = "Favor Preencher a Data de Admissão do Colaborador";
                txtRE.Focus();
                return;
            }
            if (idColaborador == null && txtNome.Text != "")
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
            sql = "UPDATE colaborador SET nome=@nome,re=@re,data_admissao=@data_admissao,observacoes=@observacoes WHERE idColaborador=@idColaborador";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", idColaborador);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@re", txtRE.Text);
            cmd.Parameters.AddWithValue("@data_admissao", Convert.ToDateTime(txtDataAdmissao.Text));
            cmd.Parameters.AddWithValue("@observacoes", txtobs.Text);

            cmd.ExecuteNonQuery();

            painelOk.Visible = true;
            lblMensagemOK.Text = "Dados Alterados com Sucesso!";
            return;
            con.FecharCon();
            Response.Redirect("produtos.aspx");
        }

        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO colaborador(nome,re,data_admissao,observacoes) VALUES(@nome,@re,@data_admissao,@observacoes)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@re", txtRE.Text);
            cmd.Parameters.AddWithValue("@data_admissao", Convert.ToDateTime(txtDataAdmissao.Text));
            cmd.Parameters.AddWithValue("@observacoes", txtobs.Text);

            cmd.ExecuteNonQuery();

            painelOk.Visible = true;
            lblMensagemOK.Text = "Dados Inseridos com Sucesso!";

            con.FecharCon();
            txtNome.Text = string.Empty;
            txtRE.Text = string.Empty;
            txtDataAdmissao.Text = string.Empty;
            txtobs.Text = string.Empty;
            return;
            Response.Redirect("colaborador.aspx");

        }


    }
}