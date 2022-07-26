using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreetingAnimalsAPI.Data;
using GreetingAnimalsAPI.Models;
using GreetingAnimalsAPI.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace GreetingAnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AdminRepository adminRepository;
        private IConfiguration _config;

        /// <summary>
        /// Initialization Login Controller
        /// </summary>
        /// <param name="context"></param>
        /// <param name="config"></param>
        public LoginController(EntityContext context, IConfiguration config)
        {
            adminRepository = new AdminRepository(context);
            this._config = config;
        }

        /// <summary>
        /// Admin Login
        /// </summary>
        /// <param name="adminLogin"></param>
        /// <returns>ResultLogin</returns>
        [HttpPost]
        [Route("AdminLogin")]
        public async Task<ResultLogin> AdminLogin(AdminLogin adminLogin)
        {
            ResultLogin result = new ResultLogin();
            Admin admin = adminRepository.checkLogin(adminLogin);

            if (admin != null)
            {
                result.Token = getToken(admin);
                result.Admin = admin ;
                return result;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// get Token by Admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        private string getToken(Admin admin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claimList = new[]
            {
                new Claim("id", admin.Id.ToString()),
                new Claim("email", admin.Email.ToString()),
                new Claim("name", admin.Name.ToString()),
                new Claim("avartar", admin.Avartar.ToString()),
                new Claim("numPhone", admin.NumPhone.ToString()),
                new Claim("address", admin.Address.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: claimList,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
