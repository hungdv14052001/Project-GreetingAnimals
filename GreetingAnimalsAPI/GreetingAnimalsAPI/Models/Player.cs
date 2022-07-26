using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class Player : BaseEntity
    {
        private string name;
        private string avartar;
        private DateTime dateofbirth;
        private string numPhone;
        private string address;
        private string tag;
        private int level;
        private int experience;
        private int rank;
        private int gold;
        private int diamond;

        /// <summary>
        /// Player initialization without parameter
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Player initialization with parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="avartar"></param>
        /// <param name="dateofbirth"></param>
        /// <param name="numPhone"></param>
        /// <param name="address"></param>
        /// <param name="tag"></param>
        /// <param name="level"></param>
        /// <param name="experience"></param>
        /// <param name="rank"></param>
        /// <param name="gold"></param>
        /// <param name="diamond"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedDate"></param>
        public Player(int id, string name, string avartar, DateTime dateofbirth, string numPhone, string address, string tag, int level, int experience, int rank, int gold, int diamond, DateTime createdDate, DateTime updatedDate) : base(id, createdDate, updatedDate)
        {
            this.name = name;
            this.avartar = avartar;
            this.dateofbirth = dateofbirth;
            this.numPhone = numPhone;
            this.address = address;
            this.tag = tag;
            this.level = level;
            this.experience = experience;
            this.rank = rank;
            this.gold = gold;
            this.diamond = diamond;
        }

        public string Name { get => name; set => name = value; }
        public string Avartar { get => avartar; set => avartar = value; }
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        public string NumPhone { get => numPhone; set => numPhone = value; }
        public string Address { get => address; set => address = value; }
        public string Tag { get => tag; set => tag = value; }
        public int Level { get => level; set => level = value; }
        public int Experience { get => experience; set => experience = value; }
        public int Rank { get => rank; set => rank = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Diamond { get => diamond; set => diamond = value; }
    }
}
