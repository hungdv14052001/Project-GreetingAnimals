using GreetingAnimalsAPI.Dto;
using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Response
{
    public class LoginRespone
    {
        private string token;
        private AdminDto admin;

        /// <summary>
        /// Login Respone initialization without parameter
        /// </summary>
        public LoginRespone()
        {

        }

        /// <summary>
        /// Login Respone initialization with parameter
        /// </summary>
        /// <param name="token"></param>
        /// <param name="admin"></param>
        public LoginRespone(string token, AdminDto admin)
        {
            this.token = token;
            this.admin = admin;
        }

        public string Token { get => token; set => token = value; }
        public AdminDto Admin { get => admin; set => admin = value; }
    }
}
