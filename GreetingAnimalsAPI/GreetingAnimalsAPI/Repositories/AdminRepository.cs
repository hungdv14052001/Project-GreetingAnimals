using GreetingAnimalsAPI.Data;
using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Repositories
{
    public class AdminRepository : BaseRepository<Admin>
    {
        /// <summary>
        /// Initialization Admin Repository
        /// </summary>
        /// <param name="ctx"></param>
        public AdminRepository(EntityContext ctx) : base(ctx)
        {
        }
        
        public Admin checkLogin(AdminLogin adminLogin)
        {
            Admin admin= null;
            foreach(Admin a in GetAllEntity())
            {
                if (a.Email.Equals(adminLogin.UserName) && a.Password.Equals(adminLogin.Password))
                {
                    admin = a;
                }
            }
            return admin;
        }
    }
}
