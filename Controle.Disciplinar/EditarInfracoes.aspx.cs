using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class EditarInfracoes : System.Web.UI.Page
    {
        string advertenciaID;
        string infracoesID;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            infracoesID = Request.QueryString["infracoesID"];
            txtAdvertenciaID.Text = advertenciaID;
            txtInracoesID.Text = infracoesID;
            if (!this.IsPostBack)
            {
                Listar();
                carregarCboxItem();
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
        protected void cboxItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboxItem.SelectedValue))
            {
                carregarCboxSubItem(int.Parse(cboxItem.SelectedValue));
                cboxArtigo.Items.Clear();
                cboxInciso.Items.Clear();
                TextBoxView.Text = string.Empty;
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
            sql = "SELECT subitemID, CONCAT(subitem, ' ', subitem.descricao) as fulldescricao FROM subitem join item on subitem.itemID = item.itemID where item.itemID=@itemID";
            //sql = "SELECT subItemID, CONCAT(subItem, ' ', descricao) as fulldescricao FROM subitem";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@itemID", cboxItem.SelectedValue);
            da.SelectCommand = cmd;
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
            sql = "UPDATE infracoes SET itemID=@itemID,subItemID=@subItemID,artigoID=@artigoID,incisoID=@incisoID,medida=@medida where infracoesID=@infracoesID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@infracoesID", Convert.ToInt32(txtInracoesID.Text));
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
            //Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "script", "<script>alert('Mensagem do Alert');location.href='pagina.html';</script>")
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);

            carregarCboxItem();
            cboxSubItem.Items.Clear();
            cboxArtigo.Items.Clear();
            cboxInciso.Items.Clear();
            cboxMedida.SelectedIndex = 0;
            TextBoxView.Text = string.Empty;

            con.FecharCon();
            
            //Response.Redirect("ver.aspx?advertenciaID=" + Session["advf"]);
            return;

        }

        private void SalvarSemInfracao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "UPDATE infracoes SET itemID=@itemID,subItemID=@subItemID,artigoID=@artigoID,incisoID=@incisoID,medida@medida where infracoesID=@infracoesID)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@infracoesID", Convert.ToInt32(txtInracoesID.Text));
            cmd.Parameters.AddWithValue("@itemID", null);
            cmd.Parameters.AddWithValue("@subItemID", null);
            cmd.Parameters.AddWithValue("@artigoID", null);
            cmd.Parameters.AddWithValue("@incisoID", null);
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
        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT infracoes.infracoesID,advertencia.advertenciaID, advertencia.dataOcorrencia,infracoes.medida,advertencia.observacoes,infracoes.itemID,infracoes.subItemID,infracoes.artigoID,infracoes.incisoID,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join infracoes on advertencia.advertenciaID = infracoes.advertenciaID inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador WHERE infracoes.infracoesID=@infracoesID";
            //sql = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,infracoes.medida,advertencia.observacoes,item.itemID,subitem.subItemID,artigo.artigoID,inciso.incisoID,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join item on advertencia.itemID = item.itemID inner join subitem ON advertencia.subItemID = subitem.subItemID inner join artigo ON advertencia.artigoID = artigo.artigoID inner join inciso on advertencia.incisoID = inciso.incisoID inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador WHERE advertencia.advertenciaID=@advertenciaID";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@infracoesID", infracoesID);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                
                string item = dt.Rows[0][5].ToString();
                if (item != "")
                {
                    carregarCboxItem();
                    cboxItem.SelectedValue = dt.Rows[0][5].ToString();
                }
                string subitem = dt.Rows[0][6].ToString();
                if (subitem != "")
                {
                    carregarCboxSubItem(Convert.ToInt32(item));
                    cboxSubItem.SelectedValue = dt.Rows[0][6].ToString();
                }
                string artigo = dt.Rows[0][7].ToString();
                if (artigo != "")
                {
                    carregarCboxArtigo(Convert.ToInt32(subitem));
                    cboxArtigo.SelectedValue = dt.Rows[0][7].ToString();
                }
                string inciso = dt.Rows[0][8].ToString();
                if (inciso != "")
                {
                    carregarCboxInciso(Convert.ToInt32(artigo));
                    cboxInciso.SelectedValue = dt.Rows[0][8].ToString();
                }
                cboxMedida.SelectedValue = dt.Rows[0][3].ToString();
                if (cboxSubItem.SelectedValue != "")
                {
                    carregarCboxSubItem(Convert.ToInt32(cboxItem.SelectedValue));
                }
            }

            con.FecharCon();
        }
    }
}