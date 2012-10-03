﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.Auth
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Boolean GetAuth = (new AuthLogic()).CheckAuth(LoginTextBox.Text, PasswordTextBox.Text);

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