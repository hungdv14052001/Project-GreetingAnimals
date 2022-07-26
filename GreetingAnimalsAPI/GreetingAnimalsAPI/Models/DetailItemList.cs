using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class DetailItemList : BaseEntity
    {
        private int idPlayer;
        private int idItem;
        private int count;

        /// <summary>
        /// Detail Item List initialization without parameter
        /// </summary>
        public DetailItemList()
        {

        }


        /// <summary>
        /// Detail Item List initialization with parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idPlayer"></param>
        /// <param name="idItem"></param>
        /// <param name="count"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedDate"></param>
        public DetailItemList(int id, int idPlayer, int idItem, int count, DateTime createdDate, DateTime updatedDate) : base(id, createdDate, updatedDate)
        {
            this.idPlayer = idPlayer;
            this.idItem = idItem;
            this.count = count;
        }

        public int IdPlayer { get => idPlayer; set => idPlayer = value; }
        public int IdItem { get => idItem; set => idItem = value; }
        public int Count { get => count; set => count = value; }
    }
}
