using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CursedProjectAN
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        private CustomMessageBox()
        {
            InitializeComponent();
        }

        //static CustomMessageBox customMessageBox;

        private static MessageBoxResult result = MessageBoxResult.None;
        public static MessageBoxResult Show(string text)
        {
            var cMessageBox = new CustomMessageBox();
            cMessageBox.TextMessageBox.Text = text;
            cMessageBox.YesButton.Visibility = Visibility.Collapsed;
            cMessageBox.NoButton.Visibility = Visibility.Collapsed;
            cMessageBox.Show();
            

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"\"{nameof(text)}\" не может быть пустым или содержать только пробел.", nameof(text));
            }

            return result;
        }

        public static MessageBoxResult ShowYN(string text)
        {
            var cMessageBox = new CustomMessageBox();
            cMessageBox.CloseButton.Visibility = Visibility.Collapsed;
            cMessageBox.TextMessageBox.Text = text;
            cMessageBox.ShowDialog();


            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"\"{nameof(text)}\" не может быть пустым или содержать только пробел.", nameof(text));
            }

            return result;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.Yes;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            result = MessageBoxResult.No;
            this.Close();
        }
    }
}
