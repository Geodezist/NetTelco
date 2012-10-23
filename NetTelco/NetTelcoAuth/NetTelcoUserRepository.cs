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

        /// <summary>
        /// Удаление пользователя по логину
        /// </summary>
        /// <param name="user_login"></param>
        /// <returns></returns>
        public bool DeleteUser(string user_login)
        {
            try
            {

                using (SecurityDBEntities db = new SecurityDBEntities())
                {
                    Users del_user = (from a in db.Users where (a.LOGIN == user_login) select a).First();
                    db.Users.DeleteObject(del_user);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false; // Ошибка при удалении
            }
        }


        /// <summary>
        /// Удаление пользователя по USER_ID
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public bool DeleteUser(Int64 user_id)
        {
            try
            {

                using (SecurityDBEntities db = new SecurityDBEntities())
                {
                    Users del_user = (from a in db.Users where (a.USER_ID == user_id) select a).First();
                    db.Users.DeleteObject(del_user);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false; // Ошибка при удалении
            }
        }

        /// <summary>
        /// Проверка, доступна ли страница requested_page для пользователя user_login.
        /// Проверка выполняется по группам, в котрые входит пользователь.
        /// </summary>
        /// <param name="user_login"></param>
        /// <param name="requested_page"></param>
        /// <returns></returns>
        public bool CheckUserPageAccess(string user_login, string requested_page)
        {

            using (SecurityDBEntities db = new SecurityDBEntities())
            {
             
                // FirsrOrDefault() для типа bool при отсутствии результата вернет false
                bool _is_user_admin = (from ua in db.Users where (ua.LOGIN == user_login) select ua.IS_ADMIN).FirstOrDefault();
                // Если пользователь является тотальным администратором, то ему доступно все и всегда.
                if (_is_user_admin)
                    return true;

                // В случае когда пользователь не тотальный администратор, то проверяем роли у этого пользователя
                // и доступна ли данная страница для групп, в которые входит данный пользователь.
                int _page = (from u in db.Users
                             join g in db.UsersInAccessGroups on u.USER_ID equals g.USER_ID
                             join gp in db.AccessPagesInAccessGroups on g.ACCESSGROUP_ID equals gp.ACCESSGROUP_ID
                             join p in db.AccessPages on gp.ACCESSPAGE_ID equals p.ACCESSPAGE_ID
                             where (u.LOGIN == user_login && p.NAME == requested_page)
                             select p.NAME).Count();
                
                // Если хотябы в одной роли страница доступна, то разрешаем показ страницы пользователю
                if (_page > 0)
                    return true;
                else
                    return false;      
            }
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


        /// <summary>
        /// Добавление пользователю группы по логину пользователя
        /// и по ACCESSGROUP_ID группы
        /// </summary>
        /// <param name="user_login"></param>
        /// <param name="accessgroup_id"></param>
        /// <returns></returns>
        public void AddUserInAccessGroup(String user_login, Int64 accessgroup_id)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                long user_id = (from u in db.Users where (u.LOGIN == user_login) select u.USER_ID).First();

                UsersInAccessGroups userinaccessgroup = new UsersInAccessGroups();
                userinaccessgroup.USER_ID = user_id;
                userinaccessgroup.ACCESSGROUP_ID = accessgroup_id;

                db.AddToUsersInAccessGroups(userinaccessgroup);
                db.SaveChanges();
            }

        }

        /// <summary>
        /// Добавление пользователю группы по USER_ID пользователя
        /// и по ACCESSGROUP_ID группы
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="accessgroup_id"></param>
        /// <returns></returns>
        public void AddUserInAccessGroup(Int64 user_id, Int64 accessgroup_id)
        {
            using (SecurityDBEntities db = new SecurityDBEntities())
            {
                UsersInAccessGroups userinaccessgroup = new UsersInAccessGroups();
                userinaccessgroup.USER_ID = user_id;
                userinaccessgroup.ACCESSGROUP_ID = accessgroup_id;

                db.AddToUsersInAccessGroups(userinaccessgroup);
                db.SaveChanges();
            }

        }


        /// <summary>
        /// Удаление у пользователю группы.
        /// </summary>
        /// <param name="uiag_id"></param>
        /// <returns></returns>
        public bool RemoveUserInAccessGroup(Int64 uiag_id)
        {
            try
            {

                using (SecurityDBEntities db = new SecurityDBEntities())
                {
                    UsersInAccessGroups deluaig = (from a in db.UsersInAccessGroups where (a.UIAG_ID == uiag_id) select a).First();
                    db.UsersInAccessGroups.DeleteObject(deluaig);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false; // Ошибка пои удалении
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