using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Model;

namespace BlogApp.BusinessLogic
{
    public static class PostActions
    {
        public static void AddPost(string body, int user_id)
        {
            using (var context = new BlogDbEntities())
            {
                Post newPost = new Post();
                newPost.Body = body;
                newPost.User_Id = user_id;
                newPost.Created_At = DateTime.Now;
                context.Post.Add(newPost);
                context.SaveChanges();
            }
        }
        public static void ModifyPost(int id, string body)
        {
            using (var context = new BlogDbEntities())
            {
                Post modifyThis = context.Post.Find(id);
                modifyThis.Body = body;
                modifyThis.Modified_At = DateTime.Now;
                context.Entry(modifyThis).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void DeletePost(int id)
        {
            using (var context = new BlogDbEntities())
            {
                Post deleteThis = context.Post.Find(id);
                context.Post.Remove(deleteThis);
                context.SaveChanges();
            }
        }
    }
}
