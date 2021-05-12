using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.SpecificationsManager
{
    public class ItemsWithCategoriesAndMeasureUnits : SpecificationsManager<Item>
    {
        public ItemsWithCategoriesAndMeasureUnits(ItemSpecParams itemParams)
            : base( x =>
                 (string.IsNullOrEmpty(itemParams.Search) || x.Name.ToLower()
                 .Contains(itemParams.Search)) &&
                 (!itemParams.CateoryId.HasValue || x.CategoryId == itemParams.CateoryId) &&
                  (!itemParams.MeasureUnitId.HasValue || x.MeasureUnitId == itemParams.MeasureUnitId))
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.MeasureUnit);
            AddOrderBy(x => x.Name);
            ApplyPaging(itemParams.PageSize * (itemParams.PageIndex - 1),
                itemParams.PageSize);


        }

        public ItemsWithCategoriesAndMeasureUnits(int id) 
            : base(x => x.Id ==id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.MeasureUnit);

        }

       
    }
}
