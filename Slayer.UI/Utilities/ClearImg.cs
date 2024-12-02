using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Slayer.UI.Utilities
{
    public static class ClearImg
    {
        public static void ClearImgValid(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is Image label)
                {
                    label.ImageUrl = string.Empty;
                   
                }
                else if (control.HasControls())
                {
                    ClearImgValid(control);
                }
            }
        }
    }
}