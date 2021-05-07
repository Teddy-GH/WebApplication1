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
        private readonly StockDbContext _context;

        //private readonly IItemRepository _repo;
        //IItemRepository repo
        public ItemController(StockDbContext context)
        {
            _context = context;
            //_repo = repo;
        }
        public ActionResult Index()
        {
            return Ok("You are here");
        }
        [HttpGet]

        public ActionResult<List<Item>> GetItems()
        {
            var items =  _context.Items.ToListAsync();
            return Ok(items);
        }

        //public   List<string> GetAll()
        //{
        //    // var items = await _repo.GetItemsAsync();
        //    List<string> lists =  new List<string>();
        //    var items =  lists;
        //    items.Add("test");
        //    return items;
        //}

        [HttpGet("{id}")]

        public async Task<ActionResult<Item>> GetItem(int id) 
        {

            return await _context.Items.FindAsync(id);
        }

        //public async Task<ActionResult<Item>> GetItem(int id)
        //{
        //    return await  _repo.GetItemByIdAsync(id);
        //}

        }
}
