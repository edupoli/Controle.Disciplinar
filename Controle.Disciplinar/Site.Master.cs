using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Controle.Disciplinar
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nome = (string)Session["nome"];
            if (nome != null)
            {
                Label1.Text = nome;
            }
            else
            {
                Response.Redirect("expirou.aspx");
            }
        }
    }
}