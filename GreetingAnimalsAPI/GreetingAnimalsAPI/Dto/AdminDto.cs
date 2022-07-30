using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Dto
{
    public class AdminDto
    {
        private string email;
        private string name;
        private string avartar;
        private DateTime dateofbirth;
        private string numPhone;
        private string address;
        private int id;


        public AdminDto()
        {

        }

        public AdminDto(Admin admin)
        {
            this.email = admin.Email;
            this.name = admin.Name;
            this.avartar = admin.Avartar;
            this.dateofbirth = admin.Dateofbirth;
            this.numPhone = admin.NumPhone;
            this.address = admin.Address;
            this.id = admin.Id;
        }
        public AdminDto(string email, string name, string avartar, DateTime dateofbirth, string numPhone, string address, int id)
        {
            this.email = email;
            this.name = name;
            this.avartar = avartar;
            this.dateofbirth = dateofbirth;
            this.numPhone = numPhone;
            this.address = address;
            this.id = id;
        }

        public string Email { get => email; set => email = value; }
        public string Name { get => name; set => name = value; }
        public string Avartar { get => avartar; set => avartar = value; }
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        public string NumPhone { get => numPhone; set => numPhone = value; }
        public string Address { get => address; set => address = value; }
        public int Id { get => id; set => id = value; }
    }
}
