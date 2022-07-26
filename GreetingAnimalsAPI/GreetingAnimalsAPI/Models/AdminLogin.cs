using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class AdminLogin
    {
        private string userName;
        private string password;

        /// <summary>
        /// AdminLogin initialization without parameter
        /// </summary>
        public AdminLogin()
        {

        }

        /// <summary>
        /// AdminLogin initialization without parameter
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public AdminLogin(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
