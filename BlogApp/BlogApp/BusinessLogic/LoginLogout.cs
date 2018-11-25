using BlogApp.BusinessLogic.Exceptions;
using BlogApp.Model;
using BlogApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLogic
{
    class LoginLogout
    {
        public static bool UserLogin(string username, string password)
        {
            using (var context = new BlogDbEntities()) // db kapcsolat
            {
                var hasUser = context.User.Any(user => user.UserName.ToLower() == username.ToLower());
                if (!hasUser)
                    throw new UserNotFoundException();
                else
                {
                    var user = context.User.Where(u => u.UserName.ToLower() == username.ToLower()).First();
                    if (user.Password != password)
                        throw new NotCorrectPasswordException();
                    else
                    {
                        UIRepository.Instance.CurrentClientId = user.Id;
                        return true;
                    }
                }
            }

        }
        public static void UserLogout()
        {
            using (var context = new BlogDbEntities())
            {
                var CurrentUser = context.User.Where(u => u.Id == UIRepository.Instance.CurrentClientId).First();
                CurrentUser.Last_Login = DateTime.Now;
                context.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            UIRepository.Instance.CurrentClientId = 0;
        }
    }
}
