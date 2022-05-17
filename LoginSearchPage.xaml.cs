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
using System.Data;
using System.Data.SqlClient;

namespace CursedProjectAN
{
    public partial class LoginSearchWindow : Page
    {

        int Tour_ID;
        int City_ID;
        Account account = Account.getInstance();
        private static readonly Regex onlyNumbers = new Regex("[^0-9]+");
        public LoginSearchWindow()
        {
            InitializeComponent();
            FillCityFrom();
            FillCityTo();
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

        private void FillCityFrom()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            con.Open();
            SqlCommand SelectCityFrom = new SqlCommand("Select * from cities", con);

            SqlDataReader SelectCityFromDataReader;
            SelectCityFromDataReader = SelectCityFrom.ExecuteReader();
            while (SelectCityFromDataReader.Read())
            {
                CityFrom.Items.Add(SelectCityFromDataReader["cityName"]);

            }
            SelectCityFromDataReader.Close();

            con.Close();
        }

        private void FillCityTo()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            con.Open();
            SqlCommand SelectCityFrom = new SqlCommand("Select * from cities", con);

            SqlDataReader SelectCityFromDataReader;
            SelectCityFromDataReader = SelectCityFrom.ExecuteReader();
            while (SelectCityFromDataReader.Read())
            {
                CityTo.Items.Add(SelectCityFromDataReader["cityName"]);

            }
            SelectCityFromDataReader.Close();

            con.Close();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (account.passportnum != null)
            {
                    if (CityFrom.SelectedItem != null)
                    {

                        if (CityTo.SelectedItem != null)
                        {
                            if (PeopleCounter.Text.Length > 0)
                            {
                                if (DayCounter.Text.Length > 0)
                                {
                                    if (PickDate.Text.Length > 0)
                                    {
                                        if (CityFrom.Text.Length > 0)
                                        {
                                            if (CityTo.Text.Length > 0)
                                            {
                                                SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                                                sqlConnection.Open();
                                                int PeopleCount = Int32.Parse(PeopleCounter.Text);
                                                int DayCount = Int32.Parse(DayCounter.Text);
                                                int Cost = 4200;
                                                if (PeopleCount >= 1)
                                                {
                                                    Cost = Cost * PeopleCount * DayCount;
                                                }
                                                SqlCommand SelectCity = new SqlCommand("SELECT cityID FROM cities WHERE cityName = @cityName", sqlConnection);
                                                SelectCity.Parameters.AddWithValue("@cityName", CityTo.Text);
                                                SqlDataReader DataReaderCity = SelectCity.ExecuteReader();
                                                while (DataReaderCity.Read())
                                                {

                                                    City_ID = (Int32)DataReaderCity.GetValue(0);

                                                 
                                                }
                                                DataReaderCity.Close();

                                                SqlCommand SelectTour = new SqlCommand("SELECT tourID FROM tours WHERE cityID = @cityID and startDate <= @startDate and endDate >= @endDate AND numberOfVouchers - @PeopleCounter >= 0", sqlConnection);
                                                SelectTour.Parameters.AddWithValue("@cityID", City_ID);
                                                SelectTour.Parameters.AddWithValue("@startDate", PickDate.Text);
                                                SelectTour.Parameters.AddWithValue("@PeopleCounter", PeopleCounter.Text);
                                                SelectTour.Parameters.AddWithValue("@endDate", Convert.ToDateTime(PickDate.Text).AddDays(Convert.ToDouble(DayCounter.Text)));
                                            var DataReaderTour = SelectTour.ExecuteReader();

                                                if (DataReaderTour.HasRows)
                                                {
                                                    while (DataReaderTour.Read())
                                                    {

                                                        Tour_ID = (Int32)DataReaderTour.GetValue(0);

                                                    }
                                                    DataReaderTour.Close();
                                                    SqlCommand sqlCommand = new SqlCommand("Insert into vouchers(cost, tourID, login, number_of_nights, [start date], number_of_people) Values(@cost, @tourID, @login, @number_of_nights, @start_date, @number_of_people)", sqlConnection);
                                                    sqlCommand.Parameters.AddWithValue("@cost", Cost);
                                                    sqlCommand.Parameters.AddWithValue("@tourID", Tour_ID);
                                                    sqlCommand.Parameters.AddWithValue("@login", account.login);
                                                    sqlCommand.Parameters.AddWithValue("@number_of_nights", Int32.Parse(DayCounter.Text));
                                                    sqlCommand.Parameters.AddWithValue("@start_date", PickDate.Text);
                                                    sqlCommand.Parameters.AddWithValue("@number_of_people", Int32.Parse(PeopleCounter.Text));
                                                    int rowsAffectedBooked = sqlCommand.ExecuteNonQuery();
                                                    if (rowsAffectedBooked > 0)
                                                    {
                                                        CustomMessageBox.Show("Забронированно");
                                                    }

                                                    else
                                                    {
                                                        CustomMessageBox.Show("Ошибка бронирования");
                                                    }

                                                    SqlCommand updateNumOfVouchers = new SqlCommand("UPDATE tours SET numberOfVouchers = numberOfVouchers - @peopleCounter WHERE tourID = @tourID", sqlConnection);
                                                    updateNumOfVouchers.Parameters.AddWithValue("@peopleCounter", PeopleCounter.Text);
                                                    updateNumOfVouchers.Parameters.AddWithValue("@tourID", Tour_ID);
                                                    updateNumOfVouchers.ExecuteScalar();

                                                    sqlConnection.Close();


                                                }

                                                else
                                                {
                                                    MessageBoxResult result = CustomMessageBox.ShowYN("Записи о туре отсутствуют. Открыть список туров?");
                                                    switch (result)
                                                    {
                                                        case MessageBoxResult.Yes:
                                                            FoundPage foundPage = new FoundPage();
                                                            NavigationService.Navigate(foundPage);
                                                            break;
                                                        case MessageBoxResult.No:

                                                            break;
                                                    }
                                                }



                                            }
                                            else CustomMessageBox.Show("Выберите город прибытия");
                                        }
                                        else CustomMessageBox.Show("Выберите город отправления");
                                    }
                                    else CustomMessageBox.Show("Выберите дату");
                                }
                                else CustomMessageBox.Show("Выберите длительность поездки");
                            }
                            else CustomMessageBox.Show("Укажите количество людей");
                        }
                        else CustomMessageBox.Show("Укажите город прибытия");
                    }
                    else CustomMessageBox.Show("Укажите город отправки");
            }
            else CustomMessageBox.Show("Заполните данные аккаунта");
        }

        private void ToSearchAll_Click(object sender, RoutedEventArgs e)
        {
            var ClickedButton = e.OriginalSource as NavButton;
            NavigationService.Navigate(ClickedButton.NavUri);
        }
    }
}
