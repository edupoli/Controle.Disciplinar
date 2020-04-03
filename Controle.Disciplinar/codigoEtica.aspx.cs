using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class About : Page
    {
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            painelErroGrid.Visible = false;
            if (!this.IsPostBack)
            {
                if (cboxTipo.SelectedValue == "codEtica")
                {
                    carregarCboxItem();
                }
                if (cboxTipo.SelectedValue == "regulamento")
                {
                    carregarCboxItemRegulamento();
                }

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        private void Salvar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO item(item,descricao) VALUES(@item,@descricao)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@item", item.Text);
            cmd.Parameters.AddWithValue("@descricao", descricao.Text);

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            //            painelOk.Visible = true;
            //            lblMensagemOK.Text = "Dados Inseridos com Sucesso!";

            con.FecharCon();
            item.Text = string.Empty;
            descricao.Text = string.Empty;
            carregarCboxItem();
            return;
            Response.Redirect("colaborador.aspx");

        }
        private void SalvarSubItem()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO subitem(subitem,descricao,regulamentoID) VALUES(@item,@descricao,@regulamentoID)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@item", subIem.Text);
            cmd.Parameters.AddWithValue("@descricao", descricaoSubItem.Text);
            cmd.Parameters.AddWithValue("@regulamentoID", cboxItem.SelectedValue);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            //            painelOk.Visible = true;
            //            lblMensagemOK.Text = "Dados Inseridos com Sucesso!";

            con.FecharCon();
            carregarCboxSubItem(int.Parse(cboxItem.SelectedValue));
            //subIem.Text = string.Empty;
            //descricaoSubItem.Text = string.Empty;
            return;
            Response.Redirect("colaborador.aspx");
        }
        private void SalvarArtigo()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO artigo(artigo,descricao,subItemID) VALUES(@artigo,@descricao,@subItemID)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@artigo", artigo.Text);
            cmd.Parameters.AddWithValue("@descricao", descricaoArtigo.Text);
            cmd.Parameters.AddWithValue("@subItemID", cboxSubItem.SelectedValue);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            //            painelOk.Visible = true;
            //            lblMensagemOK.Text = "Dados Inseridos com Sucesso!";

            con.FecharCon();
            carregarCboxArtigo(int.Parse(cboxSubItem.SelectedValue));
            //artigo.Text = string.Empty;
            //descricaoArtigo.Text = string.Empty;
            return;
            Response.Redirect("colaborador.aspx");
        }
        private void SalvarInciso()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO inciso(inciso,descricao,artigoID) VALUES(@inciso,@descricao,@artigoID)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@inciso", inciso.Text);
            cmd.Parameters.AddWithValue("@descricao", descricaoInciso.Text);
            cmd.Parameters.AddWithValue("@artigoID", cboxArtigo.SelectedValue);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            //            painelOk.Visible = true;
            //            lblMensagemOK.Text = "Dados Inseridos com Sucesso!";

            con.FecharCon();
            carregarCboxInciso(int.Parse(cboxSubItem.SelectedValue));
            //artigo.Text = string.Empty;
            //descricaoArtigo.Text = string.Empty;
            return;
            Response.Redirect("colaborador.aspx");
        }

        protected void btnSubItem_Click(object sender, EventArgs e)
        {
            if (subIem.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorSubItem();", true);
            }
            else
            {
                if (descricaoSubItem.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "errorSubItemDescricao();", true);
                }

                else
                {
                    if (cboxItem.SelectedIndex.ToString() == "0")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Popup", "errorItemID();", true);
                    }

                    else
                    {
                        if (subIem.Text != "" && descricaoSubItem.Text != "" && cboxItem.SelectedIndex != 0)
                        {
                           SalvarSubItem();
                        }
                    }

                }

            }

        }
        protected void carregarCboxItem()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            sql = "SELECT itemID, CONCAT(item, ' ', descricao) as fulldescricao FROM item";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(ds);
            cboxItem.DataSource = ds;
            cboxItem.DataTextField = "fulldescricao";
            cboxItem.DataValueField = "itemID";
            cboxItem.DataBind();
            cboxItem.Items.Insert(0, new ListItem("--SELECIONE--", ""));
            con.FecharCon();
        }
        protected void carregarCboxItemRegulamento()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            sql = "SELECT regulamentoID, CONCAT(item, ' ', descricao) as fulldescricao FROM regulamento";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(ds);
            cboxItem.DataSource = ds;
            cboxItem.DataTextField = "fulldescricao";
            cboxItem.DataValueField = "regulamentoID";
            cboxItem.DataBind();
            cboxItem.Items.Insert(0, new ListItem("--SELECIONE--", ""));
            con.FecharCon();
        }
        protected void carregarCboxSubItem(int itemID)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            if (cboxTipo.SelectedValue == "codEtica")
            {
                sql = "SELECT subitemID, CONCAT(subitem, ' ', subitem.descricao) as fulldescricao FROM subitem join item on subitem.itemID = item.itemID where item.itemID=@itemID";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@itemID", cboxItem.SelectedValue);
                da.SelectCommand = cmd;
            }
            if (cboxTipo.SelectedValue == "regulamento")
            {
                sql = "SELECT subitemID, CONCAT(subitem, ' ', subitem.descricao) as fulldescricao FROM subitem join regulamento on subitem.regulamentoID = regulamento.regulamentoID where regulamento.regulamentoID=@regulamentoID";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@regulamentoID", cboxItem.SelectedValue);
                da.SelectCommand = cmd;
            }

            //sql = "SELECT subItemID, CONCAT(subItem, ' ', descricao) as fulldescricao FROM subitem";
            da.Fill(ds);
            da.Fill(dt);
            if (ds.Tables[0].Rows.Count == 0)
            {
                cboxSubItem.Items.Clear();
                //TextBoxView.Text = string.Empty;
            }
            else
            {
                cboxSubItem.DataSource = ds;
                cboxSubItem.DataTextField = "fulldescricao";
                cboxSubItem.DataValueField = "subitemID";
                cboxSubItem.DataBind();
                cboxSubItem.Items.Insert(0, new ListItem("--SELECIONE--", ""));
            }
            if (cboxItem.SelectedIndex != 0)
            {
                TextBoxView.Text = cboxItem.SelectedItem.Text;
            }
            //TextBoxView.Text = dt.Rows[0][1].ToString();
            con.FecharCon();
        }
        protected void carregarCboxArtigo(int subItemID)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            sql = "SELECT artigoID, CONCAT(artigo, ' ', artigo.descricao) as fulldescricao FROM artigo join subitem on artigo.subItemID = subItem.subItemID where artigo.subItemID=@subItemID";
            //sql = "SELECT subItemID, CONCAT(subItem, ' ', descricao) as fulldescricao FROM subitem";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@subItemID", cboxSubItem.SelectedValue);
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                cboxArtigo.Items.Clear();
            }
            else
            {
                cboxArtigo.DataSource = ds;
                cboxArtigo.DataTextField = "fulldescricao";
                cboxArtigo.DataValueField = "artigoID";
                cboxArtigo.DataBind();
                cboxArtigo.Items.Insert(0, new ListItem("--SELECIONE--", ""));
            }
            con.FecharCon();
        }
        protected void carregarCboxInciso(int artigoID)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            sql = "SELECT incisoID, CONCAT(inciso, ' ', inciso.descricao) as fulldescricao FROM inciso join artigo on inciso.artigoID = artigo.artigoID where inciso.artigoID=@artigoID";
            //sql = "SELECT subItemID, CONCAT(subItem, ' ', descricao) as fulldescricao FROM subitem";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@artigoID", cboxArtigo.SelectedValue);
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                cboxInciso.Items.Clear();
            }
            else
            {
                cboxInciso.DataSource = ds;
                cboxInciso.DataTextField = "fulldescricao";
                cboxInciso.DataValueField = "incisoID";
                cboxInciso.DataBind();
                cboxInciso.Items.Insert(0, new ListItem("--SELECIONE--", ""));
            }
            con.FecharCon();
        }

        protected void cboxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxItem.SelectedValue))
            {
                carregarCboxSubItem(int.Parse(cboxItem.SelectedValue));
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = cboxItem.SelectedItem.Text;
            }
            else
            {
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = string.Empty;
            }
            
        }

        protected void btnArtigo_Click(object sender, EventArgs e)
        {
            if (artigo.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorArtigo();", true);
            }
            else
            {
                if (descricaoArtigo.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "errorArtigoDescricao();", true);
                }

                else
                {
                    if (cboxSubItem.SelectedIndex.ToString() == "-1" || cboxSubItem.SelectedIndex.ToString() == "0")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Popup", "errorSubItemID();", true);
                    }

                    else
                    {
                        if (artigo.Text != "" && descricaoArtigo.Text != "" && cboxSubItem.SelectedIndex != 0 && cboxSubItem.SelectedIndex != -1)
                        {
                            SalvarArtigo();
                        }
                    }

                }

            }
        }

        protected void cboxSubItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxSubItem.SelectedValue))
            {
                carregarCboxArtigo(int.Parse(cboxSubItem.SelectedValue));
                if (cboxArtigo.SelectedIndex != -1)
                {
                    cboxArtigo.SelectedIndex = 0;
                }

                cboxInciso.Items.Clear();
                TextBoxView.Text = cboxSubItem.SelectedItem.Text;
            }
            else
            {
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = cboxItem.SelectedItem.Text;
            }
        }

        protected void btnInciso_Click(object sender, EventArgs e)
        {
            if (inciso.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorInciso();", true);
            }
            else
            {
                if (descricaoInciso.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Popup", "errorIncisoDescricao();", true);
                }

                else
                {
                    if (cboxArtigo.SelectedIndex.ToString() == "-1" || cboxSubItem.SelectedIndex.ToString() == "0")
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Popup", "errorArtigoID();", true);
                    }

                    else
                    {
                        if (inciso.Text != "" && descricaoInciso.Text != "" && cboxArtigo.SelectedIndex != 0 && cboxArtigo.SelectedIndex != -1)
                        {
                           SalvarInciso();
                        }
                    }

                }

            }
        }

        protected void cboxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxArtigo.SelectedValue))
            {
                carregarCboxInciso(int.Parse(cboxArtigo.SelectedValue));
                TextBoxView.Text = cboxArtigo.SelectedItem.Text;
            }
            else
            {
                cboxInciso.Items.Clear();
                TextBoxView.Text = cboxSubItem.SelectedItem.Text;
            }
        }

        protected void cboxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTipo.SelectedValue == "selecione")
            {
                cboxItem.Items.Clear();
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = string.Empty;
            }
            if (cboxTipo.SelectedValue == "codEtica")
            {
                carregarCboxItem();
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = string.Empty;
            }
            if (cboxTipo.SelectedValue == "regulamento")
            {
                carregarCboxItemRegulamento();
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = string.Empty;
            }
        }

        protected void cboxInciso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxInciso.SelectedIndex != 0)
            {
                //carregarCboxInciso(int.Parse(cboxArtigo.SelectedValue));
                TextBoxView.Text = cboxInciso.SelectedItem.Text;
            }
            else
            {
                cboxInciso.SelectedIndex = 0;
                TextBoxView.Text = cboxArtigo.SelectedItem.Text;
            }
        }
    }
}