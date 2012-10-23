using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace NetTelco.NetTelcoAuth
{
    public partial class usersedit_telerik : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Переопределение обработчика события грида для выбора первой строки в гриде при загрузке страницы
            UsersEditGridView.PreRender += new EventHandler(UsersEditGridView_PreRender);
        }

        // Метод, который выделяет первую строку в гриде.
        void UsersEditGridView_PreRender(object sender, EventArgs e)
        {
            //Если это первая загрузка страницы, 
            if (!IsPostBack)
            {   
                //то выбираем первую строку.
                UsersEditGridView.MasterTableView.Items[0].Selected = true;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = UsersEditGridView.SelectedValue.ToString();
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

        protected void DeleteUser(object sender, GridCommandEventArgs e)
        {
            NetTelcoUserRepository NewUser = new NetTelcoUserRepository();
            Int64 user_id = Convert.ToInt64((e.Item as GridDataItem).GetDataKeyValue("USER_ID").ToString());
            NewUser.DeleteUser(user_id);
        }

    }
}