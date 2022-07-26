using GreetingAnimalsAPI.Data;
using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Repositories
{
    public class ItemRepository : BaseRepository<Item>
    {
        /// <summary>
        /// Initialization Item Repository
        /// </summary>
        /// <param name="ctx"></param>
        public ItemRepository(EntityContext ctx) : base(ctx)
        {
        }
    }
}
