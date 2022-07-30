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
    public class PlayersController : ControllerBase
    {
        private readonly PlayerRepository playerRepository;

        /// <summary>
        /// Initialization Player Controller
        /// </summary>
        /// <param name="context"></param>
        public PlayersController(EntityContext context)
        {
            playerRepository = new PlayerRepository(context);
        }

        /// <summary>
        /// Get list Players in API
        /// GET: api/Players
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return playerRepository.GetAllEntity();
        }

        /// <summary>
        /// get Player in API
        /// GET: api/Players/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = playerRepository.GetEntityById(id);

            if (player == null)
            {
                return NotFound("Not Found!");
            }
            else
            {
                return player;
            }
        }

        /// <summary>
        /// Update API
        /// PUT: api/Players/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="User"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, Player player)
        {
            try
            {
                playerRepository.UpdateEntity(id, player);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        /// <summary>
        /// Create new Player
        /// POST: api/Players
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Player</returns>
        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            
            try
            {
                return playerRepository.CreateEntity(player) as Player;
            }
            catch (Exception exp)
            {
                throw
            }
        }

        /// <summary>
        /// Delete Player on API
        /// DELETE: api/Players/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            try
            {
                playerRepository.DeleteEntityById(id);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }
    }
}
