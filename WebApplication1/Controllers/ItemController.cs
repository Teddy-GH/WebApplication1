using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        //private readonly StockDbContext _context;

        private readonly IItemRepository _repo;
        //IItemRepository repo
        public ItemController(IItemRepository repo)
        {
            //_context = context;
            _repo = repo;
        }
        public ActionResult Index()
        {
            return Ok("You are here");
        }

        [HttpGet]

        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await _repo.GetItemsAsync();
            return Ok(items);
        }

        

        [HttpGet("{id}")]

        public async Task<ActionResult<Item>> GetItem(int id) 
        {

            return await _repo.GetItemByIdAsync(id);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            return Ok(await _repo.GetCategoriesAsync()) ;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MeasureUnit>>> GetMeasureUnits()
        {
            return Ok(await _repo.GetMeasureUnitsAsync());
        }
    }
}
