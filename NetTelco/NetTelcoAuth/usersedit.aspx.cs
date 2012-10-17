using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class usersedit : AuthCheck
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //UsersDetailGridView.DataBind();
            //UsersEditGridView.DataBind();
        }

        public void NewUserCommand(object sender, DetailsViewCommandEventArgs a)
        {
            if (a.CommandName.Equals("InsertNewUser"))
            {
                NetTelcoUserRepository NewUser = new NetTelcoUserRepository();
                NewUser.CreateUser(
                    (UsersDetailGridView.FindControl("FIRST_NAMETextBox") as TextBox).Text.ToString(), //FirstNameTextBox.Text, 
                    (UsersDetailGridView.FindControl("LAST_NAMETextBox") as TextBox).Text.ToString(), //LastNameTextBox.Text, 
                    (UsersDetailGridView.FindControl("LOGINTextBox") as TextBox).Text.ToString(), //LoginTextBox.Text, 
                    (UsersDetailGridView.FindControl("PASSWORDTextBox") as TextBox).Text.ToString(), //PasswordTextBox.Text, 
                    null
                    );
                UsersEditGridView.DataBind();
            }
        }

        protected void AddGroupButton_Click(object sender, EventArgs e)
        {
            NetTelcoUserRepository AddUserInGroup = new NetTelcoUserRepository();

            AddUserInGroup.AddUserInAccessGroup(Convert.ToInt64( UsersEditGridView.SelectedValue.ToString()), Convert.ToInt64(NotAllowedGroups.SelectedValue.ToString()));
            AllowedGroups.DataBind();
            NotAllowedGroups.DataBind();
        }

        protected void RemoveGroupButton_Click(object sender, EventArgs e)
        {
            NetTelcoUserRepository RemoveUserInGroup = new NetTelcoUserRepository();

            RemoveUserInGroup.RemoveUserInAccessGroup(Convert.ToInt64(AllowedGroups.SelectedValue.ToString()));
            AllowedGroups.DataBind();
            NotAllowedGroups.DataBind();
        }
    }
}