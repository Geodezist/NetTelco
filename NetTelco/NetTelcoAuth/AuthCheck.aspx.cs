using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class AuthCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label L = (this.FindControl("Label1") as Label);

            if (IsPostBack)
            {
                L.Text = "Наследование работает? ДА ДА ДА !!!";
            }
            else
            {
                L.Text = "Наследование работает";
            }
        }
    }
}