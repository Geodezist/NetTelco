using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetTelco.NetTelcoAuth
{
    public partial class groupsedit : AuthCheck
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddAccessGroupButton_Click(object sender, EventArgs e)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                AccessGroups newAccessGroup = new AccessGroups();
                newAccessGroup.NAME = AccessGroupNameTextBox.Text;
                newAccessGroup.LABEL = AccessGroupLabelTextBox.Text;
                newAccessGroup.DESCRIPTION = AccessGroupDescriptionTextBox.Text;

                db.AddToAccessGroups(newAccessGroup);
                db.SaveChanges();
            }

            AccessGroupsGridView.DataBind();
        }
    }
}