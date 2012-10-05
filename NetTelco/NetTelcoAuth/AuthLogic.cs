using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetTelco.NetTelcoAuth
{
    public class AuthLogic
    {

        public Boolean CheckAuth(string UserLogin, string UserPassword)
        {
            //using (var context = new AuthDataClassesDataContext())
            //{
            //     int c = (from u in context.Users where u.LOGIN == UserLogin && u.PASSWORD == UserPassword select u).Count();
            //    if (c == 1)
            //    {
            //        return true;
            //    } else 
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

    }
}