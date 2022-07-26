
using GreetingAnimalsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<DetailItemList> DetailItemLists { get; set; }
    }
}
