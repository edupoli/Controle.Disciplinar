using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Controle.Disciplinar
{
    public partial class _Default : Page
    {
        int advertenciaID;
        Conexao con = new Conexao();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnResponder_Click(object sender, EventArgs e)
        {
            advertenciaID = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("punir.aspx?advertenciaID=" + advertenciaID);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            advertenciaID = Convert.ToInt32((sender as Button).CommandArgument);
            Excluir();
        }
        [WebMethod]
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

            return;
            con.FecharCon();
            Response.Redirect("pabx.aspx");
        }
       
    }
}