using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class Item : BaseEntity
    {
        private string name;
        private double speed;
        private double strenght;
        private double weight;
        private double height;
        private int priceBuy;
        private int priceSale;
        private int category;
        private string image;

        /// <summary>
        /// Item initialization without parameter
        /// </summary>
        public Item()
        {

        }

        /// <summary>
        /// Item initialization with parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="speed"></param>
        /// <param name="strenght"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="priceBuy"></param>
        /// <param name="priceSale"></param>
        /// <param name="category"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedDate"></param>
        public Item(int id, string name, double speed, double strenght, double weight, double height, int priceBuy, int priceSale, int category, string image, DateTime createdDate, DateTime updatedDate) : base(id, createdDate, updatedDate)
        {
            this.name = name;
            this.speed = speed;
            this.strenght = strenght;
            this.weight = weight;
            this.height = height;
            this.priceBuy = priceBuy;
            this.priceSale = priceSale;
            this.category = category;
            this.image = image;
        }

        public string Name { get => name; set => name = value; }
        public double Speed { get => speed; set => speed = value; }
        public double Strenght { get => strenght; set => strenght = value; }
        public double Weight { get => weight; set => weight = value; }
        public double Height { get => height; set => height = value; }
        public int PriceBuy { get => priceBuy; set => priceBuy = value; }
        public int PriceSale { get => priceSale; set => priceSale = value; }
        public int Category { get => category; set => category = value; }
        public string Image { get => image; set => image = value; }
    }
}
