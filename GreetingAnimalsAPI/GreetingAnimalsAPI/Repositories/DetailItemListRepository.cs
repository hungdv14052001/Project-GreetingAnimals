using GreetingAnimalsAPI.Data;
using GreetingAnimalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Repositories
{
    public class DetailItemListRepository : BaseRepository<DetailItemList>
    {
        /// <summary>
        /// Initialization Item Repository
        /// </summary>
        /// <param name="ctx"></param>
        public DetailItemListRepository(EntityContext ctx) : base(ctx)
        {
        }

        public List<DetailItemList> GetDetailItemListsByIdPlayer(int idPlayer)
        {
            var result = new List<DetailItemList>();
            result = GetAllEntity().Where(d => d.IdPlayer == idPlayer).ToList();
            return result;
        }
    }
}
