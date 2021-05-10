using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.SpecificationsManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IGenericRepository<Item> _itemsRepo;
        private readonly IGenericRepository<Category> _categoriesRepo;
        private readonly IGenericRepository<MeasureUnit> _measureUnitsRepo;

        public IMapper _mapper {get;}

        // private readonly IItemRepository _repo;
        public ItemController(IGenericRepository<Item> itemsRepo, IGenericRepository<Category> categoriesRepo, IGenericRepository<MeasureUnit> measureUnitsRepo, IMapper mapper)
        {
            _itemsRepo = itemsRepo;
            _categoriesRepo = categoriesRepo;
            _measureUnitsRepo = measureUnitsRepo;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            return Ok("You are here");
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<ResponseDTO>>> GetItems()
        {

            var spec = new ItemsWithCategoriesAndMeasureUnits();

            var items = await _itemsRepo.ListAsync(spec);

            return Ok(_mapper.
                Map<IReadOnlyList<Item>, IReadOnlyList<ResponseDTO>>(items));
        }

        

        [HttpGet("{id}")]

        public async Task<ActionResult<ResponseDTO>> GetItem(int id) 
        {
            var spec = new ItemsWithCategoriesAndMeasureUnits(id);

            var item = await _itemsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Item, ResponseDTO>(item);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            return Ok(await _categoriesRepo.ListAllAsync()) ;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MeasureUnit>>> GetMeasureUnits()
        {
            return Ok(await _measureUnitsRepo.ListAllAsync());
        }
    }
}
