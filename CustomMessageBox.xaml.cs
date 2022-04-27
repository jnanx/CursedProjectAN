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
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        private CustomMessageBox()
        {
            InitializeComponent();
        }

        //static CustomMessageBox customMessageBox;

        //static MessageBoxResult result = MessageBoxResult.No;
        public static void Show(string text)
        {
            var cMessageBox = new CustomMessageBox();
            cMessageBox.TextMessageBox.Text = text;
            cMessageBox.Show();
            

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"\"{nameof(text)}\" не может быть пустым или содержать только пробел.", nameof(text));
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
