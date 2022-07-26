using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class Admin : BaseEntity
    {
        private string email;
        private string password;
        private string name;
        private string avartar;
        private DateTime dateofbirth;
        private string numPhone;
        private string address;

        /// <summary>
        /// Admin initialization without parameter
        /// </summary>
        public Admin()
        {

        }

        /// <summary>
        /// Admin initialization with parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="avartar"></param>
        /// <param name="dateofbirth"></param>
        /// <param name="numPhone"></param>
        /// <param name="address"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedDate"></param>
        public Admin(int id, string email, string password, string name, string avartar, DateTime dateofbirth, string numPhone, string address, DateTime createdDate, DateTime updatedDate) : base(id, createdDate, updatedDate)
        {
            this.email = email;
            this.password = password;
            this.name = name;
            this.avartar = avartar;
            this.dateofbirth = dateofbirth;
            this.numPhone = numPhone;
            this.address = address;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Avartar { get => avartar; set => avartar = value; }
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        public string NumPhone { get => numPhone; set => numPhone = value; }
        public string Address { get => address; set => address = value; }
    }
}
