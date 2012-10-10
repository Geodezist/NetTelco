using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;


namespace NetTelco.NetTelcoAuth
{
    public class NetTelcoUserRepository
    {

        public MembershipUser CreateUser(string first_name, string last_name, string username, string password, string email)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                Users user = new Users();
                user.LOGIN = username;
                user.FIRST_NAME = first_name;
                user.LAST_NAME = last_name;
                user.EMAIL = email;
                user.PASSWORD_SALT = CreateSalt();
                user.PASSWORD = CreatePasswordHash(password,user.PASSWORD_SALT);
                user.CREATE_DATE = DateTime.Now;
                user.IS_ACTIVATED = false;
                user.IS_LOCKED_OUT = false;
                user.LAST_LOCKED_OUT_DATE = DateTime.Now;
                user.LAST_LOGIN_DATE = DateTime.Now;
                
                db.AddToUsers(user); 
                db.SaveChanges();

                return GetUser(username);
            }
        }


        public string GetUserNameByEmail(string email)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                var result = from u in db.Users where (u.EMAIL == email) select u;
                if (result.Count() != 0)
                {
                    var dbuser = result.FirstOrDefault();
                    return dbuser.LOGIN;
                }
                else
                {
                    return "";
                }
            }
        }

        public MembershipUser GetUser(string username)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                var result = from u in db.Users where (u.LOGIN == username) select u;
                if (result.Count() != 0)
                {
                    var dbuser = result.FirstOrDefault();
                    string _username = dbuser.LOGIN;
                    long _providerUserKey = dbuser.USER_ID;
                    string _email = dbuser.EMAIL;
                    string _passwordQuestion = "";
                    //string _comment = dbuser.Comments;
                    bool _isApproved = dbuser.IS_ACTIVATED;
                    bool _isLockedOut = dbuser.IS_LOCKED_OUT;
                    DateTime _creationDate = dbuser.CREATE_DATE;
                    DateTime _lastLoginDate = dbuser.LAST_LOGIN_DATE;
                    DateTime _lastActivityDate = DateTime.Now;
                    DateTime _lastPasswordChangedDate = DateTime.Now;
                    DateTime _lastLockedOutDate = dbuser.LAST_LOCKED_OUT_DATE;
                    MembershipUser user = new MembershipUser("NetTelcoMemProvider",
                                                            _username,
                                                            _providerUserKey,
                                                            _email,
                                                            _passwordQuestion,
                                                            "",
                                                            //_comment,
                                                            _isApproved,
                                                            _isLockedOut,
                                                            _creationDate,
                                                            _lastLoginDate,
                                                            _lastActivityDate,
                                                            _lastPasswordChangedDate,
                                                            _lastLockedOutDate);
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        public string CheckUserPageAccess(string user_login)
        {
            string str = "";
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                var _user_roles = (from r in db.UsersInAccessGroups 
                                   where (r.USER_ID == (from u in db.Users 
                                                          where (u.LOGIN == user_login) select u.USER_ID).FirstOrDefault())
                                   select r.ACCESSGROUP_ID);

                foreach (int i in _user_roles)
                    str = str + i.ToString() + "; ";
            }
            return str;        
        }




        public bool ValidateUser(string username, string password)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                var result = from u in db.Users where (u.LOGIN == username) select u;

                if (result.Count() != 0)
                {
                    var dbuser = result.First();

                    if (dbuser.PASSWORD == CreatePasswordHash(password, dbuser.PASSWORD_SALT))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }
        
        private static string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private static string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = String.Concat(pwd, salt);
            string hashedPwd =
                    FormsAuthentication.HashPasswordForStoringInConfigFile(
                    saltAndPwd, "sha1");
            return hashedPwd;
        }

    }
}