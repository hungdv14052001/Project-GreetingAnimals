using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class ResultLogin
    {
        private string token;
        private Admin admin;

        /// <summary>
        /// Result Login initialization without parameter
        /// </summary>
        public ResultLogin()
        {

        }

        /// <summary>
        /// Result Login initialization with parameter
        /// </summary>
        /// <param name="token"></param>
        /// <param name="admin"></param>
        public ResultLogin(string token, Admin admin)
        {
            this.token = token;
            this.admin = admin;
        }

        public string Token { get => token; set => token = value; }
        public Admin Admin { get => admin; set => admin = value; }
    }
}
