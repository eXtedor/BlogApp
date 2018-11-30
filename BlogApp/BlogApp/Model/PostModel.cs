using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Model
{
    class PostModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created_At { get; set; }
        public Nullable<System.DateTime> Modified_At { get; set; }
        public int User_Id { get; set; }

        public User User { get; set; }
    }
}
