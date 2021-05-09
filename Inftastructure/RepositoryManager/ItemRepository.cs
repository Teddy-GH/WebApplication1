using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryManager
{
    public class ItemRepository : IItemRepository
    {
        private readonly StockDbContext _context;

        public ItemRepository(StockDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.ItemCategories.ToListAsync();

        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.MeasureUnit)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IReadOnlyList<Item>> GetItemsAsync()
        {
            return await _context.Items
                .Include(i => i.Category)
                .Include(i => i.MeasureUnit)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<MeasureUnit>> GetMeasureUnitsAsync()
        {
            return await _context.MeasureUnits.ToListAsync();

        }
    }
}
