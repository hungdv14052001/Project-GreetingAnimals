﻿using System;
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
using Microsoft.AspNetCore.Authorization;

namespace GreetingAnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly AdminRepository adminRepository;

        /// <summary>
        /// Initialization Admin Controller
        /// </summary>
        /// <param name="context"></param>
        public AdminsController(EntityContext context)
        {
            adminRepository = new AdminRepository(context);
        }

        /// <summary>
        /// Get list Admins in API
        /// GET: api/Admins
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return adminRepository.GetAllEntity();
        }

        /// <summary>
        /// get Admin in API
        /// GET: api/Admins/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Admin</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = adminRepository.GetEntityById(id);

            if (admin == null)
            {
                return NotFound("Not Found!");
            }
            else
            {
                return admin;
            }
        }
 
        /// <summary>
        /// Update API
        /// PUT: api/Admins/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, Admin admin)
        {
            try
            {
                adminRepository.UpdateEntity(id, admin);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        /// <summary>
        /// Create new Admin
        /// POST: api/Admins
        /// </summary>
        /// <param name="admin"></param>
        /// <returns>Admin</returns>
        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin(Admin admin)
        {
            try
            {
                return adminRepository.CreateEntity(admin) as Admin;
            }
            catch(Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Delete Admin on API
        /// DELETE: api/Admins/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            try
            {
                adminRepository.DeleteEntityById(id);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }
    }
}
