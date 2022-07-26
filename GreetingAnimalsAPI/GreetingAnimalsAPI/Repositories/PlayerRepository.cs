using GreetingAnimalsAPI.Data;
using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Repositories
{
    public class PlayerRepository : BaseRepository<Player>
    {
        /// <summary>
        /// Initialization Player Repository
        /// </summary>
        /// <param name="ctx"></param>
        public PlayerRepository(EntityContext ctx) : base(ctx)
        {
        }
    }
}
