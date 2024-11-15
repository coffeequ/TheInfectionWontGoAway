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

            UserPassword = stringUserData[1];
        }

        public UserData(string UserLogin, string UserPassword)
        {
            this.UserLogin = UserLogin;
            this.UserPassword = UserPassword;
        }

        // Поле логин пользователя
        public string UserLogin { get; set; }

        //Поле пароль пользователя
        public string UserPassword { get; set; }

        /// <summary>
        /// Метод для вывода информации о пользователе
        /// </summary>
        /// <returns></returns>
        public string ConclisionInf()
        {
            return $"Login: {UserLogin}, password: {UserPassword}";
        }
    }
}
