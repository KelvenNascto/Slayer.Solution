using Slayer.BLL;
using System;

namespace Slayer.UI.user
{
    public partial class ConsultaUser : System.Web.UI.Page
    {
        UsuarioBLL userBLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGv1();
        }

        //popular gv1
        public void LoadGv1()
        {
            gv1.DataSource = userBLL.GetUserBLL();
            gv1.DataBind();
        }
    }
}
