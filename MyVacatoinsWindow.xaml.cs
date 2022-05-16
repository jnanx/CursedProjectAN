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
    
    public partial class MyVacatoinsWindow : Window
    {
        Account account = Account.getInstance();
        public MyVacatoinsWindow()
        {
            InitializeComponent();
            AccountLoginText.Text = account.login;
            AllMyVacations();
        }

        private void AllMyVacations()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT dbo.countries.countryName, dbo.cities.cityName, dbo.vouchers.[start date], dbo.vouchers.number_of_nights, dbo.vouchers.number_of_people, dbo.vouchers.cost FROM     dbo.users INNER JOIN dbo.roles ON dbo.users.roleID = dbo.roles.roleID INNER JOIN dbo.clients ON dbo.users.login = dbo.clients.login INNER JOIN dbo.vouchers ON dbo.clients.login = dbo.vouchers.login INNER JOIN dbo.cities INNER JOIN dbo.countries ON dbo.cities.countryID = dbo.countries.countryID INNER JOIN dbo.tours ON dbo.cities.cityID = dbo.tours.cityID ON dbo.vouchers.tourID = dbo.tours.tourID WHERE dbo.vouchers.login =  '" + AccountLoginText.Text + "'", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            DataTable allMyVacationsList = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allMyVacationsList);
            AllMyVacationsList.ItemsSource = allMyVacationsList.DefaultView;
            sqlConnection.Close();
        } 

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            LogInMainWindow logInMainWindow = new LogInMainWindow();
            logInMainWindow.Show();
            this.Close();
        }

      
    }
}
