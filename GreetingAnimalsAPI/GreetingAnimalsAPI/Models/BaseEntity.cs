using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingAnimalsAPI.Models
{
    public class BaseEntity
    {
        private int id;
        private DateTime createdDate;
        private DateTime updatedDate;

        /// <summary>
        /// Base entity initialization without parameter
        /// </summary>
        public BaseEntity()
        {

        }

        /// <summary>
        /// Base entity initialization with parameter
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdDate"></param>
        /// <param name="updatedDate"></param>
        public BaseEntity(int id, DateTime createdDate, DateTime updatedDate)
        {
            this.id = id;
            this.createdDate = createdDate;
            this.updatedDate = updatedDate;
        }

        public int Id { get => id; set => id = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public DateTime UpdatedDate { get => updatedDate; set => updatedDate = value; }
    }
}
