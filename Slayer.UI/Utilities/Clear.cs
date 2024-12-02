using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Slayer.UI.Utilities
{
    public static class Clear
    {
        public static void ClearControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                else if (c is Label)
                {
                    ((Label)c).Text = string.Empty;

                    if (c.HasControls())
                    {
                        ClearControl(c);
                    }

                }
                else if(c is Image)
                {
                    ((Image)c).ImageUrl = string.Empty;
                }
                else if(c is DropDownList)
                {
                    ((DropDownList)c).SelectedIndex = -1;
                }
                ClearControl(c);
            }

        }
    }

}