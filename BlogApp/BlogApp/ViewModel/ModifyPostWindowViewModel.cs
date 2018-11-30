using BlogApp.BusinessLogic;
using BlogApp.Command;
using BlogApp.Model;
using BlogApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BlogApp.ViewModel
{
    class ModifyPostWindowViewModel : ObservableObject
    {
        public void SendMessage(string message)
        {
            EventAggregator.BroadCast(message);
        }
        private int GetPostId
        {
            get { return UIRepository.Instance.ModifyPost; }
        }
        private string _PostBody;
        public string PostBody
        {
            get
            {
                if (_PostBody == null)
                {
                    using (var context = new BlogDbEntities())
                    {
                        var getpost = context.Post.Where(p => p.Id == GetPostId).First();
                        _PostBody = getpost.Body;
                    }
                }
                return _PostBody;
            }
            set
            {
                _PostBody = value;
            }
        }
        public void modifyPost(int id, string body)
        {
            PostActions.ModifyPost(id, body);
            SendMessage("Posts updated");
        }
        private ICommand _ModifyPost;
        public ICommand ModifyPost
        {
            get
            {
                if (_ModifyPost == null)
                {
                    _ModifyPost = new RelayCommand(p => true, p => modifyPost(GetPostId,PostBody));
                }
                return _ModifyPost;
            }
        }
    }
}
