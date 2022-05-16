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
using System.Data;
using System.Data.SqlClient;

namespace CursedProjectAN
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Window
    {
        DataGrid CurrentTable;

        public AdminMainPage()
        {
            InitializeComponent();
        }

        private void ExitFromAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }


        private void Countries_Click(object sender, RoutedEventArgs e)
        {
            AllCountries.Visibility = Visibility.Visible;
            AllCities.Visibility = Visibility.Hidden;
            AllTours.Visibility = Visibility.Hidden;
            AllVouchers.Visibility = Visibility.Hidden;
            AllClients.Visibility = Visibility.Hidden;
            AllUsers.Visibility = Visibility.Hidden;
            AllRoles.Visibility = Visibility.Hidden;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.countries.countryID, dbo.countries.countryName FROM dbo.countries", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allCountries = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allCountries);
            AllCountries.ItemsSource = allCountries.DefaultView;
            sqlConnection.Close();
            CurrentTable = AllCountries;
        }

        private void Cities_Click(object sender, RoutedEventArgs e)
        {
            AllCountries.Visibility = Visibility.Hidden;
            AllCities.Visibility = Visibility.Visible;
            AllTours.Visibility = Visibility.Hidden;
            AllVouchers.Visibility = Visibility.Hidden;
            AllClients.Visibility = Visibility.Hidden;
            AllUsers.Visibility = Visibility.Hidden;
            AllRoles.Visibility = Visibility.Hidden;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.cities.cityID, dbo.cities.countryID, dbo.cities.cityName FROM dbo.cities", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allCities = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allCities);
            AllCities.ItemsSource = allCities.DefaultView;
            sqlConnection.Close();
        }

        private void Tours_Click(object sender, RoutedEventArgs e)
        {
            AllCountries.Visibility = Visibility.Hidden;
            AllCities.Visibility = Visibility.Hidden;
            AllTours.Visibility = Visibility.Visible;
            AllVouchers.Visibility = Visibility.Hidden;
            AllClients.Visibility = Visibility.Hidden;
            AllUsers.Visibility = Visibility.Hidden;
            AllRoles.Visibility = Visibility.Hidden;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT  dbo.tours.tourID, dbo.tours.cityID, dbo.tours.startDate, dbo.tours.endDate,  dbo.tours.numberOfVouchers,  dbo.tours.duration FROM     dbo.tours", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allTours = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allTours);
            AllTours.ItemsSource = allTours.DefaultView;
            sqlConnection.Close();
        }

        private void Vouchers_Click(object sender, RoutedEventArgs e)
        {

            AllCountries.Visibility = Visibility.Hidden;
            AllCities.Visibility = Visibility.Hidden;
            AllTours.Visibility = Visibility.Hidden;
            AllVouchers.Visibility = Visibility.Visible;
            AllClients.Visibility = Visibility.Hidden;
            AllUsers.Visibility = Visibility.Hidden;
            AllRoles.Visibility = Visibility.Hidden;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.vouchers.voucherID, dbo.vouchers.cost, dbo.vouchers.tourID, dbo.vouchers.login,  dbo.vouchers.number_of_nights, dbo.vouchers.[start date], dbo.vouchers.number_of_people FROM     dbo.vouchers", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allVouchers = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allVouchers);
            AllVouchers.ItemsSource = allVouchers.DefaultView;
            sqlConnection.Close();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            AllCountries.Visibility = Visibility.Hidden;
            AllCities.Visibility = Visibility.Hidden;
            AllTours.Visibility = Visibility.Hidden;
            AllVouchers.Visibility = Visibility.Hidden;
            AllClients.Visibility = Visibility.Visible;
            AllUsers.Visibility = Visibility.Hidden;
            AllRoles.Visibility = Visibility.Hidden;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.clients.login, dbo.clients.passportNumber, dbo.clients.passportSeries, dbo.clients.clientName, dbo.clients.clientSurname, dbo.clients.clientMiddleName, dbo.clients.sex, dbo.clients.date_of_birth, dbo.clients.phoneNumber, dbo.clients.[e-mail]  FROM   dbo.clients", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allClients = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allClients);
            AllClients.ItemsSource = allClients.DefaultView;
            sqlConnection.Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            AllCountries.Visibility = Visibility.Hidden;
            AllCities.Visibility = Visibility.Hidden;
            AllTours.Visibility = Visibility.Hidden;
            AllVouchers.Visibility = Visibility.Hidden;
            AllClients.Visibility = Visibility.Hidden;
            AllUsers.Visibility = Visibility.Visible;
            AllRoles.Visibility = Visibility.Hidden;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.users.login, dbo.users.password, dbo.users.roleID FROM   dbo.users", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allUsers = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allUsers);
            AllUsers.ItemsSource = allUsers.DefaultView;
            sqlConnection.Close();
        }

        private void Roles_Click(object sender, RoutedEventArgs e)
        {
            AllCountries.Visibility = Visibility.Hidden;
            AllCities.Visibility = Visibility.Hidden;
            AllTours.Visibility = Visibility.Hidden;
            AllVouchers.Visibility = Visibility.Hidden;
            AllClients.Visibility = Visibility.Hidden;
            AllUsers.Visibility = Visibility.Hidden;
            AllRoles.Visibility = Visibility.Visible;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.roles.roleID, dbo.roles.roleName FROM     dbo.roles", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allRoles = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allRoles);
            AllRoles.ItemsSource = allRoles.DefaultView;
            sqlConnection.Close();
        }

        private void NewAdmin_Click(object sender, RoutedEventArgs e)
        {
            NewAdminWindow newAdminWindow = new NewAdminWindow();
            newAdminWindow.Show();
            this.Close();
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True"))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Contries WHERE countryID = @CountryID", conn);
                    conn.Open();
                    foreach (DataRowView item in AllCountries.ItemsSource)
                    {
                        sqlCommand.Parameters.AddWithValue("@countryID", item.Row.ItemArray[0]);
                        var reader = sqlCommand.ExecuteReader();
                        if (reader.HasRows)
                        {

                        }
                    }
                }
            }
        }

        private void AllCountries_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            Console.WriteLine(string.Join(" ", (AllCountries.SelectedItem as DataRowView).Row.ItemArray));
            var row = (AllCountries.SelectedItem as DataRowView).Row.ItemArray;
            if (row[0].ToString() != "" && row[1].ToString() != "")
            {
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE countries SET countryName = @countryName WHERE countryID = @countryID", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@countryID", row[0]);
                sqlCommand.Parameters.AddWithValue("@countryName", row[1]);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            } 
        }

    }
}
