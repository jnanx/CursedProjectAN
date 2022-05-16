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
    /// Логика взаимодействия для AccountWindow.xaml
    /// </summary>
    public partial class AccountWindow : Window
    {

        Account account = Account.getInstance();

        private bool isAlreadyHaveAccInfo = false;
        public AccountWindow()
        {
            InitializeComponent();
            AccountLoginBox.Text = account.login;
            AccountNameBox.Text = account.name;
            AccountSurnameBox.Text = account.surname;
            AccountMiddleNameBox.Text = account.middlename;
            AccountPassportNumberBox.Text = account.passportnum;
            AccountPassportSeriesBox.Text = account.passportser;
            AccountEmailBox.Text = account.mail;
            AccountPhoneNumberBox.Text = account.phonenum;
            AccountSexBox.Text = account.sex;
            DateOfBirthPicker.Text = account.dateofbirth;
            CheckForAcc();

        }

        private void CheckForAcc()
        {
            SqlConnection toAccountData = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
            toAccountData.Open();
            int i = 0;
            SqlCommand AccountData = new SqlCommand("SELECT login, clientName, clientSurname, clientMiddlename, passportNumber," +
                " passportSeries, [e-mail], phoneNumber, date_of_birth, sex FROM clients WHERE login = '" + AccountLoginBox.Text + "'", toAccountData);

        
            AccountData.ExecuteNonQuery();
            DataTable containsi = new DataTable();
            SqlDataAdapter convertsqltovs = new SqlDataAdapter(AccountData);
            convertsqltovs.Fill(containsi);
            i = Convert.ToInt32(containsi.Rows.Count.ToString());
            if (i != 0)
            {
                isAlreadyHaveAccInfo = true;
            }
        }

        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            LogInMainWindow logInMainWindow = new LogInMainWindow();
            logInMainWindow.Show();
            this.Close();
        }

        private void ExitFromAccount_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }





        private void EditAcount_Click(object sender, RoutedEventArgs e)
        {
            AccountNameBox.IsEnabled = true;
            AccountSurnameBox.IsEnabled = true;
            AccountMiddleNameBox.IsEnabled = true;
            AccountPassportNumberBox.IsEnabled = true;
            AccountPassportSeriesBox.IsEnabled = true;
            AccountEmailBox.IsEnabled = true;
            AccountPhoneNumberBox.IsEnabled = true;
            AccountSexBox.IsEnabled = true;
            DateOfBirthPicker.IsEnabled = true;
        }

        private void SaveAccountButton_Click(object sender, RoutedEventArgs e)
        {

            {
                if (!string.IsNullOrWhiteSpace(AccountNameBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(AccountSurnameBox.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(AccountPassportNumberBox.Text))
                        {
                            if (!string.IsNullOrWhiteSpace(AccountEmailBox.Text))
                            {
                                if (!string.IsNullOrWhiteSpace(AccountPhoneNumberBox.Text))
                                {
                                    if (!string.IsNullOrWhiteSpace(AccountSexBox.Text))
                                    {
                                        if (!string.IsNullOrWhiteSpace(DateOfBirthPicker.Text))
                                        {
                                            string[] dataLogin = AccountEmailBox.Text.Split('@');
                                            if (dataLogin.Length == 2)
                                            {
                                                string[] data2Login = dataLogin[1].Split('.');
                                                if (data2Login.Length == 2)
                                                {

                                                    CheckForAcc();
                                                    SqlConnection toAccountData = new SqlConnection(@"Data Source=LAPTOP-BFCVFHEM\SQLEXPRESS;Initial Catalog=TOUR_AGENCY;Integrated Security=True");
                                                    toAccountData.Open();
                                                    /*int i = 0;
                                                    SqlCommand AccountData = new SqlCommand("SELECT login, clientName, clientSurname, clientMiddlename, passportNumber," +
                                                        " passportSeries, [e-mail], phoneNumber, date_of_birth, sex FROM clients WHERE login = '" + AccountLoginBox.Text + "' AND clientName ='" + AccountNameBox.Text + "' AND clientSurname ='" + AccountSurnameBox.Text + "' AND " +
                                                        "clientMiddlename ='" + AccountMiddleNameBox.Text + "' AND  passportNumber ='" + AccountPassportNumberBox.Text + "' AND passportSeries ='" + AccountPassportSeriesBox.Text +
                                                        "' AND [e-mail] ='" + AccountEmailBox.Text + "' AND  phoneNumber ='" + AccountPhoneNumberBox.Text + "' AND  date_of_birth ='" + DateOfBirthPicker.Text + "' AND  sex ='" + AccountSexBox.Text + "'", toAccountData);
                                                    AccountData.ExecuteNonQuery();
                                                    DataTable containsi = new DataTable();
                                                    SqlDataAdapter convertsqltovs = new SqlDataAdapter(AccountData);
                                                    convertsqltovs.Fill(containsi);
                                                    i = Convert.ToInt32(containsi.Rows.Count.ToString());*/

                                                    if (!isAlreadyHaveAccInfo)
                                                    {
                                                        SqlCommand command = new SqlCommand(null, toAccountData); //вставка в таблицу
                                                        command.CommandText =
                                                    "INSERT INTO clients (login, clientName, clientSurname, clientMiddlename, passportNumber, passportSeries, " +
                                                    "[e-mail],  phoneNumber, date_of_birth, sex)" +
                                                    "VALUES ( @Login,  @Name, @Surname, @MiddleName, @PassNumber, @PassSeries, @EMail, @Phone, @DateOfBirth, @Sex)";
                                                        SqlParameter LoginParam = new SqlParameter("@Login", SqlDbType.NVarChar, 120);
                                                        SqlParameter NameParam = new SqlParameter("@Name", SqlDbType.NVarChar, 120);
                                                        SqlParameter SurnameParam = new SqlParameter("@Surname", SqlDbType.NVarChar, 120);
                                                        SqlParameter MiddleNameParam = new SqlParameter("@MiddleName", SqlDbType.NVarChar, 120);
                                                        MiddleNameParam.IsNullable = true;
                                                        SqlParameter PassNumberParam = new SqlParameter("@PassNumber", SqlDbType.NVarChar, 50);
                                                        SqlParameter PassSeriesParam = new SqlParameter("@PassSeries", SqlDbType.Int);
                                                        PassSeriesParam.IsNullable = true;
                                                        SqlParameter EMailParam = new SqlParameter("@EMail", SqlDbType.NVarChar, 120);
                                                        SqlParameter PhoneParam = new SqlParameter("@Phone", SqlDbType.NVarChar, 120);
                                                        SqlParameter DateOfBirthParam = new SqlParameter("@DateOfBirth", SqlDbType.Date);
                                                        SqlParameter SexParam = new SqlParameter("@Sex", SqlDbType.Char, 1);

                                                        LoginParam.Value = AccountLoginBox.Text;
                                                        NameParam.Value = AccountNameBox.Text;
                                                        SurnameParam.Value = AccountSurnameBox.Text;
                                                        MiddleNameParam.Value = AccountMiddleNameBox.Text;
                                                        PassNumberParam.Value = AccountPassportNumberBox.Text;
                                                        if (string.IsNullOrWhiteSpace(AccountPassportSeriesBox.Text))
                                                        {
                                                            PassSeriesParam.Value = DBNull.Value;
                                                        }
                                                        else
                                                        {
                                                            PassSeriesParam.Value = Convert.ToInt32(AccountPassportSeriesBox.Text);
                                                        }
                                                        EMailParam.Value = AccountEmailBox.Text;
                                                        PhoneParam.Value = AccountPhoneNumberBox.Text;
                                                        DateOfBirthParam.Value = DateOfBirthPicker.Text;
                                                        SexParam.Value = AccountSexBox.Text;

                                                        command.Parameters.Add(LoginParam);
                                                        command.Parameters.Add(NameParam);
                                                        command.Parameters.Add(SurnameParam);
                                                        command.Parameters.Add(MiddleNameParam);
                                                        command.Parameters.Add(PassNumberParam);
                                                        command.Parameters.Add(PassSeriesParam);
                                                        command.Parameters.Add(EMailParam);
                                                        command.Parameters.Add(PhoneParam);
                                                        command.Parameters.Add(DateOfBirthParam);
                                                        command.Parameters.Add(SexParam);

                                                        command.Prepare();

                                                        command.ExecuteNonQuery();

                                                        //добавить к полям аккаунта значения
                                                        //подобного плана:
                                                        account.name = AccountNameBox.Text;

                                                        account.surname = AccountSurnameBox.Text;
                                                        account.middlename = AccountMiddleNameBox.Text;
                                                        account.passportnum = AccountPassportNumberBox.Text;
                                                        account.passportser = AccountPassportSeriesBox.Text;
                                                        account.mail = AccountEmailBox.Text;
                                                        account.phonenum = AccountPhoneNumberBox.Text;
                                                        account.sex = AccountSexBox.Text;
                                                        account.dateofbirth = DateOfBirthPicker.Text;

                                                    }
                                                    else if (isAlreadyHaveAccInfo)
                                                    {
                                                        SqlCommand command1 = new SqlCommand(null, toAccountData);
                                                        command1.CommandText = "UPDATE clients SET login = @Login, clientName = @Name, clientSurname = @Surname, clientMiddlename = @MiddleName, passportNumber = @PassNumber, passportSeries = @PassSeries, " +
                                                    "[e-mail] = @EMail,  phoneNumber = @Phone, date_of_birth =  @DateOfBirth, sex = @Sex WHERE login = '" + AccountLoginBox.Text + "'";
                                                        SqlParameter NameParam = new SqlParameter("@Name", SqlDbType.NVarChar, 120);
                                                        SqlParameter LoginParam = new SqlParameter("@Login", SqlDbType.NVarChar, 120);
                                                        SqlParameter SurnameParam = new SqlParameter("@Surname", SqlDbType.NVarChar, 120);
                                                        SqlParameter MiddleNameParam = new SqlParameter("@MiddleName", SqlDbType.NVarChar, 120);
                                                        MiddleNameParam.IsNullable = true;
                                                        SqlParameter PassNumberParam = new SqlParameter("@PassNumber", SqlDbType.NVarChar, 50);
                                                        SqlParameter PassSeriesParam = new SqlParameter("@PassSeries", SqlDbType.Int);
                                                        PassSeriesParam.IsNullable = true;
                                                        SqlParameter EMailParam = new SqlParameter("@EMail", SqlDbType.NVarChar, 120);
                                                        SqlParameter PhoneParam = new SqlParameter("@Phone", SqlDbType.NVarChar, 120);
                                                        SqlParameter DateOfBirthParam = new SqlParameter("@DateOfBirth", SqlDbType.Date);
                                                        SqlParameter SexParam = new SqlParameter("@Sex", SqlDbType.Char, 1);

                                                        LoginParam.Value = AccountLoginBox.Text;
                                                        NameParam.Value = AccountNameBox.Text;
                                                        SurnameParam.Value = AccountSurnameBox.Text;
                                                        MiddleNameParam.Value = AccountMiddleNameBox.Text;
                                                        PassNumberParam.Value = AccountPassportNumberBox.Text;
                                                        if (string.IsNullOrWhiteSpace(AccountPassportSeriesBox.Text))
                                                        {
                                                            PassSeriesParam.Value = DBNull.Value;
                                                        }
                                                        else
                                                        {
                                                            PassSeriesParam.Value = Convert.ToInt32(AccountPassportSeriesBox.Text);
                                                        }
                                                        EMailParam.Value = AccountEmailBox.Text;
                                                        PhoneParam.Value = AccountPhoneNumberBox.Text;
                                                        DateOfBirthParam.Value = DateOfBirthPicker.Text;
                                                        SexParam.Value = AccountSexBox.Text;


                                                        command1.Parameters.Add(LoginParam);
                                                        command1.Parameters.Add(NameParam);
                                                        command1.Parameters.Add(SurnameParam);
                                                        command1.Parameters.Add(MiddleNameParam);
                                                        command1.Parameters.Add(PassNumberParam);
                                                        command1.Parameters.Add(PassSeriesParam);
                                                        command1.Parameters.Add(EMailParam);
                                                        command1.Parameters.Add(PhoneParam);
                                                        command1.Parameters.Add(DateOfBirthParam);
                                                        command1.Parameters.Add(SexParam);

                                                        command1.Prepare();

                                                        command1.ExecuteNonQuery();

                                                        //обновить все поля аккаунта
                                                        account.name = AccountNameBox.Text;


                                                        account.surname = AccountSurnameBox.Text;
                                                        account.middlename = AccountMiddleNameBox.Text;
                                                        account.passportnum = AccountPassportNumberBox.Text;
                                                        account.passportser = AccountPassportSeriesBox.Text;
                                                        account.mail = AccountEmailBox.Text;
                                                        account.phonenum = AccountPhoneNumberBox.Text;
                                                        account.sex = AccountSexBox.Text;
                                                        account.dateofbirth = DateOfBirthPicker.Text;

                                                    }

                                                    LogInMainWindow logInMainWindow = new LogInMainWindow();
                                                    logInMainWindow.Show();
                                                    this.Close();

                                                }

                                                else
                                                {
                                                    CustomMessageBox.Show("Укажите верный формат почты");
                                                }

                                            }
                                            else
                                            {
                                                CustomMessageBox.Show("Укажите верный формат почты");
                                            }
                                        }
                                        else
                                        {
                                            CustomMessageBox.Show("Выберите дату рождения");
                                        }
                                    }
                                    else
                                    {
                                        CustomMessageBox.Show("Выберите пол");
                                    }
                                }
                                else
                                {
                                    CustomMessageBox.Show("Введите номер телефона");
                                }
                            }
                            else
                            {
                                CustomMessageBox.Show("Введите почту");
                            }
                        }
                        else
                        {
                            CustomMessageBox.Show("Введите номер паспорта");
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show("Введите фамилию");
                    }

                }
                else
                {
                    CustomMessageBox.Show("Введите имя");
                }
            }

        }
    }
}