using BlogApp.BusinessLogic;
using BlogApp.BusinessLogic.Exceptions;
using BlogApp.Command;
using BlogApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BlogApp.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        string _UserName;
        [Required(ErrorMessage = "Felhasználónév kötelező!")]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                ValidateProperty("UserName", value);
            }
        }
        string _Password;
        [Required(ErrorMessage = "Jelszó kötelező!")]
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                ValidateProperty("Password", value);
            }
        }
       
        public void UserLogin(string username, string password)
        {
            try
            {
                if (LoginLogout.UserLogin(username, password))
                {
                    new MainContainerWindow().Show();
                    Application.Current.MainWindow.Close();
                }
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show("Ilyen felhasználó nem létezik!");
            }
            catch (NotCorrectPasswordException)
            {
                MessageBox.Show("Helytelen jelszó!");
            }
        }

        private ICommand _Login;
        public ICommand Login
        {
            get
            {
                if (_Login == null)
                {
                    _Login = new RelayCommand(p => true, p => this.UserLogin(UserName, Password));
                }
                return _Login;
            }
        }
    }
}
