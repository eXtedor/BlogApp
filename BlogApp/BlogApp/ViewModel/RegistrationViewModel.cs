using BlogApp.BusinessLogic;
using BlogApp.BusinessLogic.Exceptions;
using BlogApp.Command;
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
    class RegistrationViewModel : ObservableObject
    {
        private string _FirstName;
        [Required(ErrorMessage = "Keresztnév kötelező!")] 
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
                ValidateProperty("FirstName", value);
            }
        }
        private string _LastName;
        [Required(ErrorMessage = "Vezetéknév kötelező!")]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
                ValidateProperty("LastName", value);
            }
        }
        private string _UserName;
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
        private string _userPassword;
        [Required(ErrorMessage = "Jelszó kötelező!")]
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
                ValidateProperty("UserPassword", value);
            }
        }
        private string _retryPassword;
        [Required(ErrorMessage = "Kérem erősítse meg jelszavát!")]
        public string RetryPassword
        {
            get { return _retryPassword; }
            set
            {
                _retryPassword = value;
                ValidateProperty("RetryPassword", value);
            }
        }
        private ICommand _doRegistration;
        public ICommand DoRegistration
        {
            get
            {
                if (_doRegistration == null)
                {
                    _doRegistration = new RelayCommand(p => true, p => RegisterUser(UserName, UserPassword, RetryPassword, FirstName, LastName));
                }
                return _doRegistration;
            }
        }
        public void RegisterUser(string username, string password, string RetryPassword, string FirstName, string LastName)
        {
            Validate();
            if (IsValid)
            {
                try
                {
                    Registration.RegisterUser(username, password, RetryPassword, FirstName, LastName);
                    MessageBox.Show("Sikeres regisztáció!");
                }
                catch (UserAlreadyExistsException)
                {
                    MessageBox.Show("Ez a felhasználó már létezik!");
                }
                catch (PasswordsNotEqualException)
                {
                    MessageBox.Show("A két jelszónak meg kell egyeznie!");
                }
            }
        }
    }
}
