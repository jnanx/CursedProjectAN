using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursedProjectAN
{
    public class Account
    {

        private static Account _insctance;

        public static Account getInstance() => _insctance ?? (_insctance = new Account());
        private Account()
        {

        }

        public string login;
        public string password;
        public string passportnum;
        public string passportser;
        public string name;
        public string surname;
        public string middlename;
        public string sex;
        public string dateofbirth;
        public string phonenum;
        public string mail;
        public int numofvouchers;
        public int role;

        //public string password;

    }
}
