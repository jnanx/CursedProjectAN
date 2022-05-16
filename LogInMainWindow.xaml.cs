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
    /// Логика взаимодействия для LogInMainWindow.xaml
    /// </summary>
    public partial class LogInMainWindow : Window
    {
        public LogInMainWindow()
        {
            InitializeComponent();
        }


        private void Account_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow accountwindow = new AccountWindow();
            accountwindow.Show();
            this.Close();
        }

        private void YoVacations_Click(object sender, RoutedEventArgs e)
        {
            MyVacatoinsWindow myVacatoinsWindow = new MyVacatoinsWindow();
            myVacatoinsWindow.Show();
            this.Close();
        }
    }
}
