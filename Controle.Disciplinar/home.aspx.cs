using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Controle.Disciplinar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Conexao con = new Conexao();
        int advertenciaID;   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //advertencia.DataSource = GetData("SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,advertencia.observacoes,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador");
                //advertencia.DataBind();
                BindGrid();
                
            }
            
        }
        protected void BindGrid()
        {
            try
            {
                DataTable ds = new DataTable();
                con.AbrirCon();
                string cmdstr = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia, infracoes.medida, advertencia.observacoes, advertencia.usuario, colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador left join infracoes on advertencia.advertenciaID = infracoes.advertenciaID";
                //string cmdstr = "SELECT advertencia.advertenciaID, advertencia.dataOcorrencia,advertencia.observacoes,colaborador.nome,colaborador.re,colaborador.data_admissao FROM advertencia inner join colaborador ON advertencia.idColaborador = colaborador.idColaborador";
                MySqlCommand cmd = new MySqlCommand(cmdstr, con.con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.ExecuteNonQuery();
                
                if (ds.Rows.Count > 0)
                {
                    painelErroGrid.Visible = false;
                    advertencia.DataSource = ds;
                    advertencia.DataBind();
                }
                else
                {
                    painelErroGrid.Visible = true;
                    gridMensagemErro.Text = "Não existem Lançamentos Cadastrados!";
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.FecharCon();
            }
            
            

        }
        /*
        private static DataTable GetData(string query)
        {
 
            {

               string strConnString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

                using (MySqlConnection con = new MySqlConnection(strConnString))
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = query;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        */
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string advertenciaID = advertencia.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView infracoes = e.Row.FindControl("infracoes") as GridView;

                DataSet ds = new DataSet();
                con.AbrirCon();
                string cmdstr = "select infracoes.advertenciaID, item.item, subitem.subItem,artigo.artigo,inciso.inciso,infracoes.medida from infracoes right join item on infracoes.itemID = item.itemID right join subitem on infracoes.subItemID = subitem.subItemID left join artigo on infracoes.artigoID = artigo.artigoID left join inciso on infracoes.incisoID = inciso.incisoID where infracoes.advertenciaID =@advertenciaID";
                MySqlCommand cmd = new MySqlCommand(cmdstr, con.con);
                cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.ExecuteNonQuery();
                //con.FecharCon();

                infracoes.DataSource = ds;
                infracoes.DataBind();

                if (e.Row.RowIndex >= 0)
                {
                    string medida = DataBinder.Eval(e.Row.DataItem, "medida").ToString();
                    if (medida == "Feedback")
                    {
                        e.Row.Cells[6].BackColor = Color.Violet;
                        e.Row.Cells[6].ForeColor = Color.White;
                    }
                    if (medida == "Orientação")
                    {
                        e.Row.Cells[6].BackColor = Color.DarkCyan;
                        e.Row.Cells[6].ForeColor = Color.White;
                    }
                    if (medida == "Advertencia Verbal")
                    {
                        e.Row.Cells[6].BackColor = Color.Green;
                        e.Row.Cells[6].ForeColor = Color.White;
                    }
                    if (medida == "Advertencia Escrita")
                    {
                        e.Row.Cells[6].BackColor = Color.Yellow;
                        e.Row.Cells[6].ForeColor = Color.Black;
                    }
                    if (medida == "Suspensão")
                    {
                        e.Row.Cells[6].BackColor = Color.Red;
                        e.Row.Cells[6].ForeColor = Color.White;
                    }
                    
                }
            }
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            advertenciaID = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("ver.aspx?advertenciaID=" + advertenciaID);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            advertenciaID = Convert.ToInt32((sender as Button).CommandArgument);
            Excluir();
        }
        private void Excluir()
        {

            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "DELETE FROM advertencia WHERE advertenciaID=@advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucessoExcluir();", true);
            BindGrid();
            //con.FecharCon();
            //Response.Redirect("home.aspx");
            return;
        }

        protected void btnNotificar_Click(object sender, EventArgs e)
        {
            advertenciaID = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("notificacao.aspx?advertenciaID=" + advertenciaID );
            //Response.RedirectLocation("notificacao.aspx?advertenciaID=" + advertenciaID);
           // Response.Write("notificacao.aspx?advertenciaID=" + advertenciaID );
            //Response.Write("<script>window.open('notificacao.aspx?advertenciaID='+ {advertenciaID}   ,'_blank')</script>"); 
        }
    }
}
