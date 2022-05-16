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

    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LogLoginBox.Text))
            {
                if (!string.IsNullOrWhiteSpace(LogPasswordBox.Password))

                {
                    /* bool en = true;
                     bool number = false;
                     bool letter = false; */

                    // if (LogPasswordBox.Password.Length >= 2)
                    // {

                    /*    for (int i = 0; i < LogPasswordBox.Password.Length; i++) // перебираем символы
                        {
                            if (LogPasswordBox.Password[i] >= 'А' && LogPasswordBox.Password[i] <= 'Я' && LogPasswordBox.Password[i] >= 'а' && LogPasswordBox.Password[i] <= 'я') en = false;
                            if (LogPasswordBox.Password[i] >= '0' && LogPasswordBox.Password[i] <= '9') number = true;
                            if (LogPasswordBox.Password[i] >= 'A' && LogPasswordBox.Password[i] <= 'Z' && LogPasswordBox.Password[i] >= 'a' && LogPasswordBox.Password[i] <= 'z') letter = true;
                        }
                    }


                    if (!en)
                        MessageBox.Show("Доступна только английская раскладка");
                    else if (!number)
                        MessageBox.Show("Добавьте хотя бы одну цифру");
                    else if (!letter)
                        MessageBox.Show("Добавьте хотя бы одну букву");
                    if (en && number && letter)
                    {
                   */
                    SqlConnection toLogin = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                    toLogin.Open();
                    int i = 0;
                    SqlCommand login = new SqlCommand("SELECT login, password FROM users WHERE login = '" + LogLoginBox.Text + "' AND password ='" + LogPasswordBox.Password + "'", toLogin);
                    login.ExecuteNonQuery();
                    DataTable containsi = new DataTable();
                    SqlDataAdapter convertsqltovs = new SqlDataAdapter(login);
                    convertsqltovs.Fill(containsi);
                    i = Convert.ToInt32(containsi.Rows.Count.ToString());

                    SqlParameter RoleParam = new SqlParameter("@RoleID", SqlDbType.Char, 1);

                    if (i == 0)
                    {
                        CustomMessageBox.Show("Неверный логин или пароль");
                    }
                    else
                    {

                        var account = Account.getInstance();
                        account.login = LogLoginBox.Text;
                        account.password = LogPasswordBox.Password;
                        
                        SqlCommand GetClientName = new SqlCommand("SELECT clientName FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var name = GetClientName.ExecuteScalar();
                        if (name != null)
                            account.name = name.ToString();

                        SqlCommand GetClientSurname = new SqlCommand("SELECT clientSurname FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var surname = GetClientSurname.ExecuteScalar();
                        if (surname != null)
                            account.surname = surname.ToString();

                        SqlCommand GetClientMiddleName = new SqlCommand("SELECT clientMiddlename FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var middlename = GetClientMiddleName.ExecuteScalar();
                        if (middlename != null)
                            account.middlename = middlename.ToString();

                        SqlCommand GetClientPassNum = new SqlCommand("SELECT passportNumber FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var passnum = GetClientPassNum.ExecuteScalar();
                        if (passnum != null)
                            account.passportnum = passnum.ToString();

                        SqlCommand GetClientPassSer = new SqlCommand("SELECT passportSeries FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var passser = GetClientPassSer.ExecuteScalar();
                        if (passser != null)
                            account.passportser = passser.ToString();

                        SqlCommand GetClientEmail = new SqlCommand("SELECT [e-mail] FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var email= GetClientEmail.ExecuteScalar();
                        if (email != null)
                            account.mail = email.ToString();

                        SqlCommand GetClientPhone = new SqlCommand("SELECT phoneNumber FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var phone = GetClientPhone.ExecuteScalar();
                        if (phone != null)
                            account.phonenum = phone.ToString();

                        SqlCommand GetClientDateOfBirth = new SqlCommand("SELECT date_of_birth FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var Dateofbirth = GetClientDateOfBirth.ExecuteScalar();
                        if (Dateofbirth != null)
                            account.dateofbirth = Dateofbirth.ToString();

                        SqlCommand GetClientSex = new SqlCommand("SELECT sex FROM clients WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var Sex = GetClientSex.ExecuteScalar();
                        if (Sex != null)
                            account.sex = Sex.ToString();

                        SqlCommand GetClientRole = new SqlCommand("SELECT roleID FROM users WHERE login = '" + LogLoginBox.Text + "'", toLogin);
                        var role = GetClientRole.ExecuteScalar();
                        if (role != null)
                            account.role =
                            Convert.ToInt32(role.ToString());
                        if (account.role == 1)
                        {
                            LogInMainWindow logInMainWindow = new LogInMainWindow();
                            logInMainWindow.Show();
                            this.Close();
                        }
                        if (account.role == 0)
                        {
                            AdminMainPage adminMainPage = new AdminMainPage();
                            adminMainPage.Show();
                            this.Close();
                        }


                    }
                    toLogin.Close();
                }
                else {
                    CustomMessageBox.Show("Введите пароль");
                }

                } else
            {
                CustomMessageBox.Show("Введите логин");
            }

            }


            private void ToRegistrationButton(object sender, RoutedEventArgs e)
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                registrationWindow.Show();
                this.Close();
            }

            private void LogLoginBox_Down(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    LogPasswordBox.Focus();
                }
            }

        }
    }

