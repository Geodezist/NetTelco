using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetTelco.BIZ
{
    public class BizUserLogic
    {
        public List<Users> GetAllUsers()
        {
            using (var context = new UsersDataClassesDataContext())
            {
                return (from u in context.Users select u).ToList();
            }
        }

        public void DeleteUserByID(int ID)
        {
            var context = new UsersDataClassesDataContext();

            var deleteUserID = from userID in context.Users
                               where userID.ID == ID
                               select userID;

            //foreach (var deleteU in deleteUserID)
            //{
            //    context.Users.DeleteOnSubmit(deleteU);
            //}

            context.Users.DeleteAllOnSubmit(deleteUserID);

            try
            {
                context.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}