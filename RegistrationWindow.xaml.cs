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

namespace CursedProjectAN
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            LogInMainWindow logInMainWindow = new LogInMainWindow();
            logInMainWindow.Show();
            this.Close();
        }

        private void ToLoginButton(object sender, RoutedEventArgs e)
        {
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
            this.Close();
        }
        private void RegLoginBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegMailBox.Focus();
            }
        }

        private void RegMailBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegPasswordBox.Focus();
            }
        }

        private void RegPasswordBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegRepeatPasswordBox.Focus();
            }
        }
    }
}
