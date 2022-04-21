using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursedProjectAN
{
    /// <summary>
    /// Логика взаимодействия для LoginSearchWindow.xaml
    /// </summary>
    public partial class LoginSearchWindow : Page
    {

        private static readonly Regex onlyNumbers = new Regex("[^0-9]+");
        public LoginSearchWindow()
        {
            InitializeComponent();
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DayCounter.Text)) DayCounter.Text = (Convert.ToInt32(DayCounter.Text) < 30 ? (Convert.ToInt32(DayCounter.Text) + 1) : Convert.ToInt32(DayCounter.Text)).ToString();
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DayCounter.Text)) DayCounter.Text = (Convert.ToInt32(DayCounter.Text) > 1 ? (Convert.ToInt32(DayCounter.Text) - 1) : Convert.ToInt32(DayCounter.Text)).ToString();
        }

        private void DayCounter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = onlyNumbers.IsMatch(e.Text);

        }


        private void DayCounter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DayCounter.Text) && Convert.ToInt32(DayCounter.Text) > 30) DayCounter.Text = "30";
            if (!string.IsNullOrWhiteSpace(DayCounter.Text) && Convert.ToInt32(DayCounter.Text) == 0) DayCounter.Text = "1";
        }

        private void PlusPeopleButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PeopleCounter.Text)) PeopleCounter.Text = (Convert.ToInt32(PeopleCounter.Text) < 10 ? (Convert.ToInt32(PeopleCounter.Text) + 1) : Convert.ToInt32(PeopleCounter.Text)).ToString();
        }

        private void MinusPeopleButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PeopleCounter.Text)) PeopleCounter.Text = (Convert.ToInt32(PeopleCounter.Text) > 1 ? (Convert.ToInt32(PeopleCounter.Text) - 1) : Convert.ToInt32(PeopleCounter.Text)).ToString();
        }

        private void PeopleCounter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = onlyNumbers.IsMatch(e.Text);

        }

        private void PeopleCounter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PeopleCounter.Text) && Convert.ToInt32(PeopleCounter.Text) > 10) PeopleCounter.Text = "10";
            if (!string.IsNullOrWhiteSpace(PeopleCounter.Text) && Convert.ToInt32(PeopleCounter.Text) == 0) PeopleCounter.Text = "1";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var ClickedButton = e.OriginalSource as NavButton;
            NavigationService.Navigate(ClickedButton.NavUri);
        }
    }
}
