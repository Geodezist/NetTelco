using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            bool GetAuth = (new NetTelcoUserRepository()).ValidateUser(LoginTextBox.Text, PasswordTextBox.Text);

            if (GetAuth)
            { 
                LoginErrorLabel.Text = "УРА! ПОЛУЧИЛОСЬ";
            } else
            {
                LoginErrorLabel.Text = "НИФИГА!!!";
            }
            LoginErrorLabel.Visible = true;
        }
    }
}