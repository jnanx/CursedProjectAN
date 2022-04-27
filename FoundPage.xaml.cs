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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace CursedProjectAN
{
    /// <summary>
    /// Логика взаимодействия для FoundPage.xaml
    /// </summary>
    public partial class FoundPage : Page
    {
        public FoundPage()
        {
            InitializeComponent();
            ToursListView();
        }

        private void ToursListView()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.countries.countryName, dbo.cities.cityName, dbo.tours.startDate, dbo.tours.endDate,  dbo.tours.duration, dbo.tours.numberOfVouchers FROM     dbo.tours INNER JOIN dbo.cities ON dbo.tours.cityID = dbo.cities.cityID INNER JOIN dbo.countries ON dbo.cities.countryID = dbo.countries.countryID", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allTours = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allTours);
            AllTours.ItemsSource = allTours.DefaultView;
            sqlConnection.Close();
        }

        private void SearchFromAll_Click(object sender, RoutedEventArgs e)
        {
            if (SearchWithCountry.IsChecked == true) {
            AllTours.Visibility = Visibility.Hidden;
            AllSearchedTours.Visibility = Visibility.Visible;
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlSearchedToursCommand = new SqlCommand("SELECT dbo.countries.countryName, dbo.cities.cityName, dbo.tours.startDate, dbo.tours.endDate,  dbo.tours.duration, dbo.tours.numberOfVouchers FROM     dbo.tours INNER JOIN dbo.cities ON dbo.tours.cityID = dbo.cities.cityID INNER JOIN dbo.countries ON dbo.cities.countryID = dbo.countries.countryID WHERE countryName = '"+ SearchTextBox.Text+ "'", sqlConnection);
            sqlSearchedToursCommand.ExecuteNonQuery();
            DataTable allSearchedTours = new DataTable();
            SqlDataAdapter sqlDataSearchedToursAdapter = new SqlDataAdapter(sqlSearchedToursCommand);
            sqlDataSearchedToursAdapter.Fill(allSearchedTours);
            AllSearchedTours.ItemsSource = allSearchedTours.DefaultView;
            sqlConnection.Close();
            } 

            if (SearchWithCity.IsChecked == true)
            {
                AllTours.Visibility = Visibility.Hidden;
                AllSearchedTours.Visibility = Visibility.Visible;
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                sqlConnection.Open();
                SqlCommand sqlSearchedToursCommand = new SqlCommand("SELECT dbo.countries.countryName, dbo.cities.cityName, dbo.tours.startDate, dbo.tours.endDate,  dbo.tours.duration, dbo.tours.numberOfVouchers FROM     dbo.tours INNER JOIN dbo.cities ON dbo.tours.cityID = dbo.cities.cityID INNER JOIN dbo.countries ON dbo.cities.countryID = dbo.countries.countryID WHERE cityName = '" + SearchTextBox.Text + "'", sqlConnection);
                sqlSearchedToursCommand.ExecuteNonQuery();
                DataTable allSearchedTours = new DataTable();
                SqlDataAdapter sqlDataSearchedToursAdapter = new SqlDataAdapter(sqlSearchedToursCommand);
                sqlDataSearchedToursAdapter.Fill(allSearchedTours);
                AllSearchedTours.ItemsSource = allSearchedTours.DefaultView;
                sqlConnection.Close();
            }
            

            if (SearchWithStartDate.IsChecked == true)
            {
                AllTours.Visibility = Visibility.Hidden;
                AllSearchedTours.Visibility = Visibility.Visible;
                PickStartDate.Visibility = Visibility.Visible;
                if (PickStartDate.SelectedDate != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                    sqlConnection.Open();
                    SqlCommand sqlSearchedToursCommand = new SqlCommand("SELECT dbo.countries.countryName, dbo.cities.cityName, dbo.tours.startDate, dbo.tours.endDate,  dbo.tours.duration, dbo.tours.numberOfVouchers FROM     dbo.tours INNER JOIN dbo.cities ON dbo.tours.cityID = dbo.cities.cityID INNER JOIN dbo.countries ON dbo.cities.countryID = dbo.countries.countryID WHERE startDate = '" + PickStartDate.Text + "'", sqlConnection);
                    sqlSearchedToursCommand.ExecuteNonQuery();
                    DataTable allSearchedTours = new DataTable();
                    SqlDataAdapter sqlDataSearchedToursAdapter = new SqlDataAdapter(sqlSearchedToursCommand);
                    sqlDataSearchedToursAdapter.Fill(allSearchedTours);
                    AllSearchedTours.ItemsSource = allSearchedTours.DefaultView;
                    sqlConnection.Close();
                }
            }

            if (SearchWithEndDate.IsChecked == true)
            {
                AllTours.Visibility = Visibility.Hidden;
                AllSearchedTours.Visibility = Visibility.Visible;
                PickEndDate.Visibility = Visibility.Visible;
                if (PickEndDate.SelectedDate != null)
                {
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                    sqlConnection.Open();
                    SqlCommand sqlSearchedToursCommand = new SqlCommand("SELECT dbo.countries.countryName, dbo.cities.cityName, dbo.tours.startDate, dbo.tours.endDate,  dbo.tours.duration, dbo.tours.numberOfVouchers FROM     dbo.tours INNER JOIN dbo.cities ON dbo.tours.cityID = dbo.cities.cityID INNER JOIN dbo.countries ON dbo.cities.countryID = dbo.countries.countryID WHERE endDate = '" + PickEndDate.Text + "'", sqlConnection);
                    sqlSearchedToursCommand.ExecuteNonQuery();
                    DataTable allSearchedTours = new DataTable();
                    SqlDataAdapter sqlDataSearchedToursAdapter = new SqlDataAdapter(sqlSearchedToursCommand);
                    sqlDataSearchedToursAdapter.Fill(allSearchedTours);
                    AllSearchedTours.ItemsSource = allSearchedTours.DefaultView;
                    sqlConnection.Close();
                }
            }
        }

        
    }

}
