using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class AccessAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            NetTelcoUserRepository NewUser = new NetTelcoUserRepository();
            NewUser.CreateUser(FirstNameTextBox.Text, LastNameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, null);
            //status = MembershipCreateStatus.Success;
        }
    }
}