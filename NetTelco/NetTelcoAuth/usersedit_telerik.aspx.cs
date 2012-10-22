using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class usersedit_telerik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = UsersEditGridView.SelectedValue.ToString();
        }

        protected void AddGroupButton_Click(object sender, EventArgs e)
        {
            NetTelcoUserRepository AddUserInGroup = new NetTelcoUserRepository();

            AddUserInGroup.AddUserInAccessGroup(Convert.ToInt64(UsersEditGridView.SelectedValue.ToString()), Convert.ToInt64(NotAllowedGroups.SelectedValue.ToString()));
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


        protected void AllowedGroups_Deleting(object sender, Telerik.Web.UI.RadListBoxDeletingEventArgs e)
        {
            NetTelcoUserRepository RemoveUserInGroup = new NetTelcoUserRepository();
            RemoveUserInGroup.RemoveUserInAccessGroup(Convert.ToInt64(e.Items[0].Value.ToString()));
        }

        protected void AllowedGroups_Inserting(object sender, Telerik.Web.UI.RadListBoxInsertingEventArgs e)
        {
            NetTelcoUserRepository AddUserInGroup = new NetTelcoUserRepository();
            AddUserInGroup.AddUserInAccessGroup(Convert.ToInt64(UsersEditGridView.SelectedValue.ToString()), Convert.ToInt64(e.Items[0].Value.ToString()));
        }

    }
}