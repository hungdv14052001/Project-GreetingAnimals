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

namespace GreetingAnimalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemRepository itemRepository;

        /// <summary>
        /// Initialization Item Controller
        /// </summary>
        /// <param name="context"></param>
        public ItemsController(EntityContext context)
        {
            itemRepository = new ItemRepository(context);
        }

        /// <summary>
        /// Get list Items in API
        /// GET: api/Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return itemRepository.GetAllEntity();
        }

        /// <summary>
        /// get Item in API
        /// GET: api/Items/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Item</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = itemRepository.GetEntityById(id);

            if (item == null)
            {
                return NotFound("Not Found!");
            }
            else
            {
                return item;
            }
        }

        /// <summary>
        /// Update API
        /// PUT: api/Items/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            try
            {
                itemRepository.UpdateEntity(id, item);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        /// <summary>
        /// Create new Item
        /// POST: api/Items
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Player</returns>
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            return itemRepository.CreateEntity(item) as Item;
        }

        /// <summary>
        /// Delete Item on API
        /// DELETE: api/Items/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                itemRepository.DeleteEntityById(id);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }
    }
}
