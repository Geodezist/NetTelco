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

        public AuthCheck() 
        {
            PreInit += new EventHandler(AuthCheckPageAccess);
        }


        void AuthCheckPageAccess(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {

                NetTelcoUserRepository UserRoles = new NetTelcoUserRepository();
                string str = UserRoles.CheckUserPageAccess(User.Identity.Name);

                Label L = (this.FindControl("Label1") as Label);
                L.Text = "Привет " + User.Identity.Name + "!" + str;
            }
            else
                Response.Redirect("~/NetTelcoAuth/Auth.aspx");
        }
    }
}