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
    public partial class addpunir : System.Web.UI.Page
    {
        string advertenciaID;
        string colaborador;
        long id;
        string sql;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            colaborador = Request.QueryString["colaborador"];
            Label1.Text = colaborador;
            txtAdvertenciaID.Text = advertenciaID;
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
        protected void carregarCboxItem()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sql = "SELECT itemID, CONCAT(item, ' ', descricao) as fulldescricao FROM item";
            cmd = new MySqlCommand(sql, con.con);
            da.SelectCommand = cmd;
            da.Fill(ds);
            da.Fill(dt);
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
        protected void cboxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxItem.SelectedValue))
            {
                carregarCboxSubItem(int.Parse(cboxItem.SelectedValue));
            }
            else
            {
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = string.Empty;
            }
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
                //cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = cboxItem.SelectedItem.Text;
            }
        }
        protected void carregarCboxArtigo(int subItemID)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sql = "SELECT artigoID, CONCAT(artigo, ' ', artigo.descricao) as fulldescricao FROM artigo join subitem on artigo.subItemID = subItem.subItemID where artigo.subItemID=@subItemID";
            //sql = "SELECT subItemID, CONCAT(subItem, ' ', descricao) as fulldescricao FROM subitem";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@subItemID", cboxSubItem.SelectedValue);
            da.SelectCommand = cmd;
            da.Fill(ds);
            da.Fill(dt);
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
            if (cboxSubItem.SelectedIndex != 0)
            {
                TextBoxView.Text = cboxSubItem.SelectedItem.Text;
            }
            //TextBoxView.Text = dt.Rows[0][1].ToString();
            con.FecharCon();
        }
        protected void carregarCboxInciso(int artigoID)
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            MySqlDataAdapter da = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sql = "SELECT incisoID, CONCAT(inciso, ' ', inciso.descricao) as fulldescricao FROM inciso join artigo on inciso.artigoID = artigo.artigoID where inciso.artigoID=@artigoID";
            //sql = "SELECT subItemID, CONCAT(subItem, ' ', descricao) as fulldescricao FROM subitem";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@artigoID", cboxArtigo.SelectedValue);
            da.SelectCommand = cmd;
            da.Fill(ds);
            da.Fill(dt);
            if (ds.Tables[0].Rows.Count == 0)
            {
                cboxInciso.Items.Clear();
                //TextBoxView.Text = string.Empty;
            }
            else
            {
                cboxInciso.DataSource = ds;
                cboxInciso.DataTextField = "fulldescricao";
                cboxInciso.DataValueField = "incisoID";
                cboxInciso.DataBind();
                cboxInciso.Items.Insert(0, new ListItem("--SELECIONE--", ""));
            }
            if (cboxArtigo.SelectedIndex != 0)
            {
                TextBoxView.Text = cboxArtigo.SelectedItem.Text;
            }

            //TextBoxView.Text = dt.Rows[0][1].ToString();
            con.FecharCon();
        }

        protected void cboxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxArtigo.SelectedValue))
            {
                carregarCboxInciso(int.Parse(cboxArtigo.SelectedValue));
            }
            else
            {
                cboxInciso.Items.Clear();
                TextBoxView.Text = cboxSubItem.SelectedItem.Text;
            }
        }

        protected void cboxInciso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxInciso.SelectedValue))
            {
                TextBoxView.Text = cboxInciso.SelectedItem.Text;
            }
            else
            {
                TextBoxView.Text = string.Empty;
            }

        }


        private void SalvarInfracao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO infracoes(advertenciaID,itemID,subItemID,artigoID,incisoID,medida) VALUES(@advertenciaID,@itemID,@subItemID,@artigoID,@incisoID,@medida)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", Convert.ToInt32(txtAdvertenciaID.Text));
            cmd.Parameters.AddWithValue("@itemID", cboxItem.SelectedValue);
            if (cboxSubItem.SelectedValue == "")
            {
                cmd.Parameters.AddWithValue("@subItemID", null);
            }
            else
                cmd.Parameters.AddWithValue("@subItemID", cboxSubItem.SelectedValue);
            if (cboxArtigo.SelectedValue == "")
            {
                cmd.Parameters.AddWithValue("@artigoID", null);
            }
            else
                cmd.Parameters.AddWithValue("@artigoID", cboxArtigo.SelectedValue);
            if (cboxInciso.SelectedValue == "")
            {
                cmd.Parameters.AddWithValue("@incisoID", null);
            }
            else
                cmd.Parameters.AddWithValue("@incisoID", cboxInciso.SelectedValue);
            cmd.Parameters.AddWithValue("@medida", cboxMedida.SelectedValue);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);

            carregarCboxItem();
            cboxSubItem.Items.Clear();
            cboxArtigo.Items.Clear();
            cboxInciso.Items.Clear();
            cboxMedida.SelectedIndex = 0;
            TextBoxView.Text = string.Empty;
            
            con.FecharCon();
            return;
            Response.Redirect("pabx.aspx");

        }

        private void SalvarSemInfracao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO infracoes(advertenciaID,medida) VALUES(@advertenciaID,@medida)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", Convert.ToInt32(txtAdvertenciaID.Text));
            cmd.Parameters.AddWithValue("@medida", cboxMedida.SelectedValue);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);

            carregarCboxItem();
            cboxSubItem.Items.Clear();
            cboxArtigo.Items.Clear();
            cboxInciso.Items.Clear();
            cboxMedida.SelectedIndex = 0;
            TextBoxView.Text = string.Empty;

            con.FecharCon();
            Response.Redirect("home.aspx");
            return;

        }

        protected void btnInfracao_Click(object sender, EventArgs e)
        {
            if (cboxItem.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorItem();", true);
            }
            if (cboxMedida.SelectedValue == "SELECIONE")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorMedida();", true);
            }
            else
                //AddNewRecordRowToGrid();
                SalvarInfracao();
            ListarInfracoes();
        }
        private void ListarInfracoes()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "select item.item,subitem.subitem, artigo.artigo, inciso.inciso, infracoes.medida  from infracoes inner join item on infracoes.itemID = item.itemID left join subitem on infracoes.subitemid = subitem.subitemid left join inciso on infracoes.incisoID = inciso.incisoID left join artigo on infracoes.itemID = artigo.artigoID where infracoes.advertenciaID = @advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", Convert.ToInt32(txtAdvertenciaID.Text));
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            // con.FecharCon();

        }

        protected void btnSemInfracao_Click(object sender, EventArgs e)
        {
            if (cboxMedida.SelectedValue == "SELECIONE")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorMedida();", true);
            }
            else
                SalvarSemInfracao();
        }

        protected void cboxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxTipo.SelectedValue == "selecione")
            {
                cboxItem.Items.Clear();
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                cboxMedida.SelectedIndex = -1;
                TextBoxView.Text = string.Empty;
            }
            if (cboxTipo.SelectedValue == "codEtica")
            {
                carregarCboxItem();
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                cboxMedida.SelectedIndex = -1;
                TextBoxView.Text = string.Empty;
            }
            if (cboxTipo.SelectedValue == "regulamento")
            {
                carregarCboxItemRegulamento();
                cboxSubItem.Items.Clear();
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                cboxMedida.SelectedIndex = -1;
                TextBoxView.Text = string.Empty;
            }
        }
    }
}