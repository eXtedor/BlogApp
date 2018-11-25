using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlogApp.View
{
    /// <summary>
    /// Interaction logic for LoginRegContainer.xaml
    /// </summary>
    public partial class LoginRegContainer : Window
    {
        Style Primary = Application.Current.FindResource("MaterialDesignRaisedButton") as Style;
        Style Secondary = Application.Current.FindResource("MaterialDesignRaisedDarkButton") as Style;
        public LoginRegContainer()
        {
            InitializeComponent();
            Main.Content = new LoginPage();
            signin.Style = Primary;
            signup.Style = Secondary;
        }
    }
}
