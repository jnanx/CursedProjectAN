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
    /// Логика взаимодействия для NewAdminWindow.xaml
    /// </summary>
    public partial class NewAdminWindow : Window
    {
        public NewAdminWindow()
        {
            InitializeComponent();
        }

        private void NewAdminLoginBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NewAdminPasswordBox.Focus();
            }
        }


        private void NewAdminPasswordBox_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                NewAdminRepeatPasswordBox.Focus();
            }
        }

        private void AddAdminButton(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewAdminLoginBox.Text))
            {
                if (!string.IsNullOrWhiteSpace(NewAdminPasswordBox.Password))
                {
                    if (!string.IsNullOrWhiteSpace(NewAdminRepeatPasswordBox.Password))
                    {
                        if (NewAdminPasswordBox.Password == NewAdminRepeatPasswordBox.Password)
                        {
                            SqlConnection toLogin = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                            toLogin.Open();
                            int i = 0;
                            SqlCommand login = new SqlCommand("SELECT login FROM users WHERE login = '" + NewAdminLoginBox.Text + "'", toLogin);
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
                                LoginParam.Value = NewAdminLoginBox.Text;
                                PasswordParam.Value = NewAdminPasswordBox.Password;
                                RoleParam.Value = 0;

                                command.Parameters.Add(LoginParam);
                                command.Parameters.Add(PasswordParam);
                                command.Parameters.Add(RoleParam);

                                command.Prepare();


                                command.ExecuteNonQuery();

                                AdminMainPage adminMainPage = new AdminMainPage();
                                adminMainPage.Show();
                                this.Close();

                            }

                            else
                            {
                                CustomMessageBox.Show("Данный админ уже зарегистрирован");
                            }
                        }
                        else
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
            else
            {
                CustomMessageBox.Show("Введите логин");
            }
        }

        private void BackToMainAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminMainPage adminMainPage = new AdminMainPage();
            adminMainPage.Show();
            this.Close();
        }
    }
}
