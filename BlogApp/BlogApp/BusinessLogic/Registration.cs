using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Model;
using BlogApp.BusinessLogic.Exceptions;

namespace BlogApp.BusinessLogic
{
    public static class Registration
    {
        public static bool HasUserName(string username)
        {
            using (var context = new BlogDbEntities())
            {
                var hasuser = context.User.Any(u => u.UserName.ToLower() == username.ToLower());
                return hasuser;
            }
        }
        public static void RegisterUser(string username, string password, string RetryPassword,
            string FirstName, string LastName)
        {

            using (var context = new BlogDbEntities())
            {
                if (HasUserName(username))
                {
                    throw new UserAlreadyExistsException();
                }
                else if (password == RetryPassword)
                {
                    User NewUser = new User();
                    NewUser.UserName = username;
                    NewUser.Password = password;
                    NewUser.FirstName = FirstName;
                    NewUser.LastName = LastName;
                    NewUser.Created_At = DateTime.Now;
                    context.User.Add(NewUser);
                    context.SaveChanges();
                }
                else
                {
                    throw new PasswordsNotEqualException();
                }
            }
        }
    }
}
