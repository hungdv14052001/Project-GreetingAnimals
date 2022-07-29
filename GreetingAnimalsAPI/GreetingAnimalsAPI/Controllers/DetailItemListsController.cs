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
    public class DetailItemListsController : ControllerBase
    {
        private readonly DetailItemListRepository detailItemListRepository;

        /// <summary>
        /// Initialization DetailItemListr Controller
        /// </summary>
        /// <param name="context"></param>
        public DetailItemListsController(EntityContext context)
        {
            detailItemListRepository = new DetailItemListRepository(context);
        }

        /// <summary>
        /// Get list DetailItemLists in API
        /// GET: api/DetailItemLists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailItemList>>> GetDetailItemLists()
        {
            return detailItemListRepository.GetAllEntity();
        }

        /// <summary>
        /// get DetailItemList in API
        /// GET: api/DetailItemLists/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DetailItemList</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailItemList>> GetDetailItemList(int id)
        {
            var detailItemList = detailItemListRepository.GetEntityById(id);

            if (detailItemList == null)
            {
                return NotFound("Not Found!");
            }
            else
            {
                return detailItemList;
            }
        }

        /// <summary>
        /// get list DetailItem of Player by idPlayer
        /// </summary>
        /// <param name="idPlayer"></param>
        /// <returns></returns>
        [HttpGet("idPlayer={idPlayer}")]
        public async Task<ActionResult<IEnumerable<DetailItemList>>> GetDetailItemListByIdPlayer(int idPlayer)
        {
            return detailItemListRepository.GetDetailItemListsByIdPlayer(idPlayer);
        }
        /// <summary>
        /// Update API
        /// PUT: api/DetailItemLists/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="detailItemList"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailItemList(int id, DetailItemList detailItemList)
        {
            try
            {
                detailItemListRepository.UpdateEntity(id, detailItemList);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }

        /// <summary>
        /// Create new DetailItemList
        /// POST: api/DetailItemLists
        /// </summary>
        /// <param name="player"></param>
        /// <returns>DetailItemList</returns>
        [HttpPost]
        public async Task<ActionResult<DetailItemList>> PostDetailItemList(DetailItemList detailItemList)
        {
            return detailItemListRepository.CreateEntity(detailItemList) as DetailItemList;
        }

        /// <summary>
        /// Delete DetailItemList on API
        /// DELETE: api/DetailItemLists/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailItemList(int id)
        {
            try
            {
                detailItemListRepository.DeleteEntityById(id);
            }
            catch
            {
                throw;
            }
            return NoContent();
        }
    }
}
