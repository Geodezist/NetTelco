using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class AuthCheck : System.Web.UI.Page
    {

        /// <summary>
        /// Finds a Control recursively. Note finds the first match and exists
        /// </summary>
        /// <param name="ContainerCtl"></param>
        /// <param name="IdToFind"></param>
        /// <returns></returns>
        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
            return null;
        }


        public AuthCheck() 
        {
            PreInit += new EventHandler(AuthCheckPageAccess);
        }


        public void AuthCheckPageAccess(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                NetTelcoUserRepository UserRoles = new NetTelcoUserRepository();
                if (!UserRoles.CheckUserPageAccess(User.Identity.Name, Page.AppRelativeVirtualPath))
                    Response.Redirect("~/NetTelcoAuth/accessdenied.aspx");
            }
            else
                Response.Redirect("~/NetTelcoAuth/Auth.aspx");
        
        }
    }
}