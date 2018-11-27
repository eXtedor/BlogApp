using BlogApp.BusinessLogic;
using BlogApp.Command;
using BlogApp.UI;
using BlogApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BlogApp.ViewModel
{
    class MainContainerWindowViewModel : ObservableObject
    {
        public int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }
        public void UserLogout()
        {
            LoginLogout.UserLogout();
            new LoginRegContainer().Show();
            Application.Current.Windows[0].Close();
        }
        private ICommand _Logout;
        public ICommand Logout
        {
            get
            {
                if (_Logout == null)
                {
                    _Logout = new RelayCommand(p => true, p => UserLogout());
                }
                return _Logout;
            }
        }
        private string _PostBody;
        public string PostBody
        {
            set
            {
                this._PostBody = value;
            }
            get
            {
                return _PostBody;
            }
        }
        private ICommand _AddPost;
        public ICommand AddPost
        {
            get
            {
                if (_AddPost == null)
                {
                    _AddPost = new RelayCommand(p => true, p => AddNewPost(PostBody, UserId));
                }
                return _AddPost;
            }
        }
        public void AddNewPost(string body, int userid)
        {
            PostActions.AddPost(body, userid);
            EventAggregator.BroadCast("Posts changed");
        }
    }
}
