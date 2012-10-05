using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace NetTelco
{
    public partial class Users : System.Web.UI.Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["SecurityDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();

        }


        private void BindData()
        {
            //Bind the grid view
            UserGrid.DataSource = RetrieveData();
            UserGrid.DataBind();
        }

        private DataSet RetrieveData()
        {
            //if (ViewState["dsProducts"] != null)
                //return (DataSet)ViewState["dsProducts"];

            //fetch the connection string from web.config
            //string connString = ConfigurationManager.ConnectionStrings["SecurityDB"].ConnectionString;

            //SQL statement to fetch entries from products
            string sql = @"SELECT * FROM [Users]";

            DataSet dsProducts = new DataSet();
            //Open SQL Connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                //Initialize command object
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    //Fill the result set
                    adapter.Fill(dsProducts);

                }
            }
            return dsProducts;
        }


        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            UserGrid.ShowFooter = true;
            BindData();
        }

        protected void userGrid_RowCommand(object sender, GridViewCommandEventArgs a)
        {
            if (a.CommandName.Equals("Insert"))
            {
                UsersDBSource.InsertCommand = "INSERT INTO Users (FIRST_NAME,LAST_NAME,MIDDLE_NAME,LOGIN,PASSWORD) VALUES ('"
                    + (UserGrid.FooterRow.FindControl("NewFIRST_NAMETextBox") as TextBox).Text.ToString() + "', '"
                    + (UserGrid.FooterRow.FindControl("NewLAST_NAMETextBox") as TextBox).Text.ToString() + "', '"
                    + (UserGrid.FooterRow.FindControl("NewMIDDLE_NAMETextBox") as TextBox).Text.ToString() + "', '"
                    + (UserGrid.FooterRow.FindControl("NewLOGINTextBox") as TextBox).Text.ToString() + "', '"
                    + (UserGrid.FooterRow.FindControl("NewPASSWORDTextBox") as TextBox).Text.ToString() + "')";
                UsersDBSource.Insert();

                Label1.Text = UsersDBSource.InsertCommand.ToString();
                BindData();
            }
            else if (a.CommandName.Equals("InsertCancel")) 
            {
                UserGrid.ShowFooter = false;
                BindData();
            }

        }

        protected void userGrid_RowEditing(object sender, GridViewEditEventArgs a) 
        {
            UserGrid.EditIndex = a.NewEditIndex;
            BindData();
        }

        protected void userGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs a)
        {
            UserGrid.EditIndex = -1;
            BindData();
        }

        protected void userGrid_RowUpdating(object sender, GridViewUpdateEventArgs a)
        {
            string USER_ID = UserGrid.DataKeys[a.RowIndex].Value.ToString();
            GridViewRow row = UserGrid.Rows[a.RowIndex];

            // Формируем строку update-а
            string updateString = String.Format("UPDATE Users SET FIRST_NAME='{0}', LAST_NAME='{1}', MIDDLE_NAME='{2}', LOGIN='{3}', PASSWORD='{4}' WHERE USER_ID={5}",
                                            (row.FindControl("UpdateFIRST_NAMETextBox") as TextBox).Text.ToString(),
                                            (row.FindControl("UpdateLAST_NAMETextBox") as TextBox).Text.ToString(),
                                            (row.FindControl("UpdateMIDDLE_NAMETextBox") as TextBox).Text.ToString(),
                                            (row.FindControl("UpdateLoginTextBox") as TextBox).Text.ToString(),
                                            (row.FindControl("UpdatePASSWORDTextBox") as TextBox).Text.ToString(),
                                            USER_ID);
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(updateString, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            UserGrid.EditIndex = -1;
            BindData();
        }

        protected void userGrid_RowDeleting(object sender, GridViewDeleteEventArgs a)
        {
            string USER_ID = UserGrid.DataKeys[a.RowIndex].Value.ToString();

            // Формируем строку delete-а

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE USER_ID="+USER_ID, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            UserGrid.EditIndex = -1;
            BindData();
        }
    }
}