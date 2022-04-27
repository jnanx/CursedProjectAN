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

    }
}
