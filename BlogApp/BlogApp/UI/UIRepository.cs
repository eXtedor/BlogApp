﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UI
{
    public class UIRepository
    {
        private static volatile UIRepository instance;
        private static object syncRoot = new Object();

        private UIRepository() { }
        public static UIRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new UIRepository();
                    }
                }

                return instance;
            }
        }

        private int _currentClientId;

        public int CurrentClientId
        {
            get { return _currentClientId; }
            set { _currentClientId = value; }
        }

        private int _modifiyPost;
        public int ModifyPost
        {
            get { return _modifiyPost; }
            set { _modifiyPost = value; }
        }
    }
}