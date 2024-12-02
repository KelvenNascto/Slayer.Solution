using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slayer.UI.user
{
    public partial class DefaultUser : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralMessage.Text = $"Seja bem {Session["User"].ToString().ToUpper()}, sua sessão inicia às {DateTime.Now.ToString("t")}";

            Response.AppendHeader("Refresh", String.Concat((Session.Timeout * 300000), ";URL=../Login.aspx"));
        }
    }
}