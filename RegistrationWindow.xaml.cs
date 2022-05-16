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
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RegLoginBox.Text))
            {
                if (!string.IsNullOrWhiteSpace(RegPasswordBox.Password))
                {
                    if (!string.IsNullOrWhiteSpace(RegRepeatPasswordBox.Password))
                    {
                        if (RegPasswordBox.Password == RegRepeatPasswordBox.Password) { 
                        SqlConnection toLogin = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                        toLogin.Open();
                        int i = 0;
                        SqlCommand login = new SqlCommand("SELECT login FROM users WHERE login = '" + RegLoginBox.Text + "'", toLogin);
                        login.ExecuteNonQuery();
                        DataTable containsi = new DataTable();
                        SqlDataAdapter convertsqltovs = new SqlDataAdapter(login);
                        convertsqltovs.Fill(containsi);
                        i = Convert.ToInt32(containsi.Rows.Count.ToString());
                        if (i == 0)
                        {
                            SqlCommand command = new SqlCommand(null, toLogin); //вставка в таблицу
                            command.CommandText =
                        "INSERT INTO users (login, password, roleID)" +
                        "VALUES (@Login, @Password,  @RoleID)";
                            SqlParameter LoginParam = new SqlParameter("@Login", SqlDbType.NVarChar, 120);
                            SqlParameter PasswordParam =
                            new SqlParameter("@Password", SqlDbType.NVarChar, 120);
                            SqlParameter RoleParam = new SqlParameter("@RoleID", SqlDbType.Char, 1);
                            LoginParam.Value = RegLoginBox.Text;
                            PasswordParam.Value = RegPasswordBox.Password;
                            RoleParam.Value = 1;

                            command.Parameters.Add(LoginParam);
                            command.Parameters.Add(PasswordParam);
                            command.Parameters.Add(RoleParam);

                            command.Prepare();


                            command.ExecuteNonQuery();

                                LoginWindow loginwindow = new LoginWindow();
                                loginwindow.Show();
                                this.Close();

                            }

                        else
                        {
                            CustomMessageBox.Show("Данный пользователь уже зарегистрирован");
                        }
                        } else
                        {
                            CustomMessageBox.Show("Пароли не совпадают");
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show("Повторите пароль");

                    }
                }
                else
                {
                    CustomMessageBox.Show("Введите пароль");
                }
            }
            else {
                CustomMessageBox.Show("Введите логин");
            }

        }

        private void ToLoginButton(object sender, RoutedEventArgs e)
        {
            LoginWindow loginwindow = new LoginWindow();
            loginwindow.Show();
            this.Close();
        }
        private void RegLoginBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegPasswordBox.Focus();
            }
        }


        private void RegPasswordBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegRepeatPasswordBox.Focus();
            }
        }
    }
}
