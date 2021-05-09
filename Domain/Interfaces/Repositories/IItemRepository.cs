using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
   public  interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<IReadOnlyList<Item>> GetItemsAsync();
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
        Task<IReadOnlyList<MeasureUnit>> GetMeasureUnitsAsync();

    }
}
