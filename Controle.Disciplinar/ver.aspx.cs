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
    public partial class ver : System.Web.UI.Page
    {
        string advertenciaID;
        string infracoesID;
        string colaboradorID;
        public string adv;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            advertenciaID = Request.QueryString["advertenciaID"];
            ListarAdvertencia();
            ListarInfracoes();
            
            
            //SqlDataSource2.SelectParameters["advertenciaID"].DefaultValue = advertenciaID;
        }
        private void ListarAdvertencia()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "select advertencia.advertenciaID, advertencia.idColaborador, advertencia.dataOcorrencia,colaborador.re, colaborador.nome,advertencia.observacoes, infracoes.infracoesID from advertencia inner join colaborador on advertencia.idColaborador = colaborador.idColaborador left join infracoes on advertencia.advertenciaID = infracoes.advertenciaID where advertencia.advertenciaID = @advertenciaID";
            //sql= "select advertencia.advertenciaID, advertencia.idColaborador, advertencia.dataOcorrencia,colaborador.re, colaborador.nome,advertencia.observacoes from advertencia inner join colaborador on advertencia.idColaborador = colaborador.idColaborador where advertencia.advertenciaID = @advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridAdvertencia.DataSource = dt;
                GridAdvertencia.DataBind();
                txtInracoesID.Text = dt.Rows[0][6].ToString();
            }
            
            con.FecharCon();
        }
        private void ListarInfracoes()
        {
            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter();
            sql = "select infracoes.advertenciaID, infracoes.infracoesID, item.item, subitem.subItem,artigo.artigo,inciso.inciso,infracoes.medida from infracoes LEFT join item on infracoes.itemID = item.itemID LEFT join subitem on infracoes.subItemID = subitem.subItemID LEFT join artigo on infracoes.artigoID = artigo.artigoID LEFT join inciso on infracoes.incisoID = inciso.incisoID where infracoes.advertenciaID = @advertenciaID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@advertenciaID", advertenciaID);
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridInfracoes.Visible = true;
                GridInfracoes.DataSource = dt;
                GridInfracoes.DataBind();
                msg.Visible = false;
            }
            else
            {
                GridInfracoes.Visible = false;
                msg.Visible = true;
            }

            con.FecharCon();
        }
        private void ExcluirInfracoes()
        {

            string sql;
            MySqlCommand cmd;
            con.AbrirCon();
            sql = "DELETE FROM infracoes WHERE infracoesID=@infracoesID";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@infracoesID", infracoesID);

            cmd.ExecuteNonQuery();
            ClientScript.RegisterStartupScript(GetType(), "Popup", "sucessoExcluir();", true);
            ListarInfracoes();
            //con.FecharCon();
            //Response.Redirect("home.aspx");
            return;
        }

        protected void GridInfracoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TextBox1.Text = GridInfracoes.SelectedRow.Cells[0].Text;
        }

        protected void GridInfracoes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridInfracoes, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para selecionar essa linha.";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            
            advertenciaID = ((sender as Button).CommandArgument);
            Response.Redirect("EditarAdvertencia.aspx?advertenciaID=" + advertenciaID);
        }

        protected void btnEditarCodigoEtica_Click(object sender, EventArgs e)
        {
            Session["advf"] = advertenciaID;
            infracoesID = ((sender as Button).CommandArgument);
            Response.Redirect("EditarInfracoes.aspx?infracoesID=" + infracoesID);
        }

        protected void btnAdicionarInfracao_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarInfracoes.aspx?infracoesID=" + txtInracoesID.Text);
        }

        protected void btnDeletarCodigoEtica_Click(object sender, EventArgs e)
        {
            infracoesID = ((sender as Button).CommandArgument);
            ExcluirInfracoes();
        }
    }
}