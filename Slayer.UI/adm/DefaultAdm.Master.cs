using System;

namespace Slayer.UI.adm
{
    public partial class DefaultAdm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralMessage.Text = $"Seja bem {Session["User"].ToString().ToUpper()}, sua sessão inicia às {DateTime.Now.ToString("t")}";

            Response.AppendHeader("Refresh", String.Concat((Session.Timeout * 300000), ";URL=../Login.aspx"));
        }
    }
}