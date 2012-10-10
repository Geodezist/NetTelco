using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NetTelco.NetTelcoAuth;

namespace NetTelco.NetTelcoAuth
{
    public partial class AccessAdmin : AuthCheck
    {

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            NetTelcoUserRepository NewUser = new NetTelcoUserRepository();
            NewUser.CreateUser(FirstNameTextBox.Text, LastNameTextBox.Text, LoginTextBox.Text, PasswordTextBox.Text, null);

        }
    }
}