﻿using BlogApp.BusinessLogic;
using BlogApp.Command;
using BlogApp.Model;
using BlogApp.UI;
using BlogApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BlogApp.ViewModel
{
    class MyPostsPageViewModel : ObservableObject
    {
        public MyPostsPageViewModel()
        {
            EventAggregator.OnMessageTransmitted += OnMessageReceived;
        }
        private void OnMessageReceived(string message)
        {
            if (message == "Posts changed") NotifyPropertyChanged("MyPosts");
            if (message == "Posts updated") NotifyPropertyChanged("MyPosts");
        }
        public int UserId
        {
            get { return UIRepository.Instance.CurrentClientId; }
        }
        private ICollection<PostModel> _MyPosts;
        public ICollection<PostModel> MyPosts
        {
            get
            {
                using (var context = new BlogDbEntities())
                {
                    _MyPosts = PostMapper.EntityCollectionToModelCollection(context.Post.Where(p=> p.User_Id == UserId).OrderByDescending(p=>p.Id).ToList());
                }
                return _MyPosts;
            }
        }
        private ICommand _ModifyPost;
        public ICommand ModifyPost
        {
            get
            {
                if (_ModifyPost == null)
                {
                    _ModifyPost = new RelayCommand(p => true, p => SetModifyableId(Convert.ToInt32(p)));
                }
                return _ModifyPost;
            }
        }
        private void SetModifyableId(int id)
        {
            UIRepository.Instance.ModifyPost = id;
            new ModifyPostWindow().Show();
        }
        private ICommand _DeletePost;
        public ICommand DeletePost
        {
            get
            {
                if (_DeletePost == null)
                {
                    _DeletePost = new RelayCommand(p => true, p => DelPost(Convert.ToInt32(p)));
                }
                return _DeletePost;
            }
        }
        private void DelPost(int id)
        {
            PostActions.DeletePost(id);
            NotifyPropertyChanged("MyPosts");
        }
    }
}
