using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Инфекция_не_пройдет.Models
{
    class UserData
    {
        public UserData(string[] stringUserData)
        {
            UserLogin = stringUserData[0];

            UserPassword = stringUserData[0];
        }

        public UserData()
        {

        }

        public string UserLogin { get; set; }

        public string UserPassword { get; set; }

        public string ConclisionInf()
        {
            return $"Login: {UserLogin}, password {UserPassword}";
        }
    }
}
