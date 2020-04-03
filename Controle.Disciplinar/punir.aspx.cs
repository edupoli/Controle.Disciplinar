using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class punir : System.Web.UI.Page
    {
        string advertenciaID;
        long id;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            txtAdvertenciaID.Text = advertenciaID;
            if (advertenciaID != null)
            {
                Listar();
                
            }
            if (!this.IsPostBack)
            {
                carregarCboxItem();
            }
            if (!IsPostBack)
            {
                //AddDefaultFirstRecord();
                infraPanel.Visible = false;
                if (advertenciaID != null)
                {
                    infraPanel.Visible = true;
                }
            }
            //infraPanel.Visible = false;
        }
        private void Listar()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,infracoes.medida,advertencia.observacoes,infracoes.itemID,infracoes.subItemID,infracoes.artigoID,infracoes.incisoID,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join infracoes on advertencia.advertenciaID = infracoes.advertenciaID inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador WHERE advertencia.advertenciaID=@advertenciaID";
            //sql = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,infracoes.medida,advertencia.observacoes,item.itemID,subitem.subItemID,artigo.artigoID,inciso.incisoID,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join item on advertencia.itemID = item.itemID inner join subitem ON advertencia.subItemID = subitem.subItemID inner join artigo ON advertencia.artigoID = artigo.artigoID inner join inciso on advertencia.incisoID = inciso.incisoID inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador WHERE advertencia.advertenciaID=@advertenciaID";
         
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                infraPanel.Visible = true;
                txtRE.Text = dt.Rows[0][9].ToString();
                txtNome.Text = dt.Rows[0][8].ToString();
                txtDataAdmissao.Text = dt.Rows[0][10].ToString();
                dataOcorrencia.Text = dt.Rows[0][1].ToString();
                string item = dt.Rows[0][4].ToString();
                if (item != "")
                {
                    carregarCboxItem();
                    cboxItem.SelectedValue = dt.Rows[0][4].ToString();
                }
                string subitem = dt.Rows[0][5].ToString();
                if (subitem != "")
                {
                    carregarCboxSubItem(Convert.ToInt32(item));
                    cboxSubItem.SelectedValue = dt.Rows[0][5].ToString();
                }
                string artigo = dt.Rows[0][6].ToString();
                if (artigo !="")
                {
                    carregarCboxArtigo(Convert.ToInt32(subitem));
                    cboxArtigo.SelectedValue = dt.Rows[0][6].ToString();
                }
                string inciso = dt.Rows[0][7].ToString();
                if (inciso != "")
                {
                    carregarCboxInciso(Convert.ToInt32(artigo));
                    cboxInciso.SelectedValue = dt.Rows[0][7].ToString();
                }
                cboxMedida.SelectedValue = dt.Rows[0][2].ToString();
                txtobs.Text = dt.Rows[0][3].ToString();
                if (cboxSubItem.SelectedValue != "")
                {
                    carregarCboxSubItem(Convert.ToInt32( cboxItem.SelectedValue));
                }
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
            }
            infraPanel.Visible = false;
            con.FecharCon();
            
        }

        protected void txtRE_TextChanged(object sender, EventArgs e)
        {
            buscaColaborador(txtRE.Text);
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
            infraPanel.Visible = true;
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
            if (cboxItem.SelectedIndex != 0 )
            {
                TextBoxView.Text = cboxItem.SelectedItem.Text;
            }
            //TextBoxView.Text = dt.Rows[0][1].ToString();
            con.FecharCon();
            infraPanel.Visible = true;
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
            infraPanel.Visible = true;
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
            infraPanel.Visible = true;
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
                infraPanel.Visible = true;
            }
            else
            {
                TextBoxView.Text = string.Empty;
            }
                                
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
            sql = "INSERT INTO advertencia(idColaborador,dataOcorrencia,observacoes) VALUES(@idColaborador,@dataOcorrencia,@observacoes)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@idColaborador", txtidColaborador.Text);
            cmd.Parameters.AddWithValue("@dataOcorrencia",Convert.ToDateTime(dataOcorrencia.Text));
            cmd.Parameters.AddWithValue("@observacoes", txtobs.Text);
            cmd.ExecuteNonQuery();
            id = cmd.LastInsertedId;
            ultimoID.Text = Convert.ToString(cmd.LastInsertedId);
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucesso();", true);
            infraPanel.Visible = true;

            //Label1.Text = "Dados Inseridos com Sucesso!";

            //con.FecharCon();
            
            return;
            Response.Redirect("pabx.aspx");

        }
        private void SalvarInfracao()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "INSERT INTO infracoes(advertenciaID,itemID,subItemID,artigoID,incisoID,medida) VALUES(@advertenciaID,@itemID,@subItemID,@artigoID,@incisoID,@medida)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", Convert.ToInt32(ultimoID.Text));
            cmd.Parameters.AddWithValue("@itemID", cboxItem.SelectedValue);
            if (cboxSubItem.SelectedValue == "")
            {
                cmd.Parameters.AddWithValue("@subItemID", null);
            }else
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

        protected void btnInfracao_Click(object sender, EventArgs e)
        {
            if (cboxMedida.SelectedValue == "SELECIONE")
            {
                ClientScript.RegisterStartupScript(GetType(), "Popup", "errorMedida();", true);
            }else
            //AddNewRecordRowToGrid();
            SalvarInfracao();
            ListarInfracoes();
        }
        private void AddDefaultFirstRecord()
        {
            //creating dataTable   
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "infracoes";
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            dt.Columns.Add(new DataColumn("SubItem", typeof(string)));
            dt.Columns.Add(new DataColumn("Artigo", typeof(string)));
            dt.Columns.Add(new DataColumn("Inciso", typeof(string)));
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            //saving databale into viewstate   
            ViewState["infracoes"] = dt;
            //bind Gridview  
           // GridView1.DataSource = dt;
           // GridView1.DataBind();
        }
        private void AddNewRecordRowToGrid()
        {
            // check view state is not null  
            if (ViewState["infracoes"] != null)
            {
                //get datatable from view state   
                DataTable dtCurrentTable = (DataTable)ViewState["infracoes"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //add each row into data table  
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Item"] = cboxItem.SelectedValue;
                        drCurrentRow["SubItem"] = cboxSubItem.SelectedValue;
                        drCurrentRow["Artigo"] = cboxArtigo.SelectedValue;
                        drCurrentRow["Inciso"] = cboxInciso.SelectedValue;


                    }
                    //Remove initial blank row  
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();

                    }

                    //add created Rows into dataTable  
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Save Data table into view state after creating each row  
                    ViewState["infracoes"] = dtCurrentTable;
                    //Bind Gridview with latest Row  
                   // GridView1.DataSource = dtCurrentTable;
                   // GridView1.DataBind();
                }
            }
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
            cmd.Parameters.AddWithValue("@advertenciaID", Convert.ToInt32(ultimoID.Text));
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
    }
}