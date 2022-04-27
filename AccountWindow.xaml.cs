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
    /// <summary>
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {
        Account account = Account.getInstance();
        public AccountWindow()
        {
            InitializeComponent();
            AccountLoginBox.Text = account.login;
        }

        
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            LogInMainWindow logInMainWindow = new LogInMainWindow();
            logInMainWindow.Show();
            this.Close();
        }

        private void ExitFromAccount_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

  

     

        private void EditAcount_Click(object sender, RoutedEventArgs e)
        {
            AccountNameBox.IsEnabled = true;
            AccountSurnameBox.IsEnabled = true;
            AccountMiddleNameBox.IsEnabled = true;
            AccountPassportNumberBox.IsEnabled = true;
            AccountPassportSeriesBox.IsEnabled = true;
            AccountEmailBox.IsEnabled = true;
            AccountPhoneNumberBox.IsEnabled = true;
            AccountSexBox.IsEnabled = true;
        }

        private void SaveAccountButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
