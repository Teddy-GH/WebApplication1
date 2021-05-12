using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.SpecificationsManager
{

    public class ItemCountSpecification : SpecificationsManager<Item>
    {
        public ItemCountSpecification(ItemSpecParams itemParams)
             : base(x =>
                (string.IsNullOrEmpty(itemParams.Search) || x.Name.ToLower()
                     .Contains(itemParams.Search)) &&
                (!itemParams.CateoryId.HasValue || x.CategoryId == itemParams.CateoryId) &&
                (!itemParams.MeasureUnitId.HasValue || x.MeasureUnitId == itemParams.MeasureUnitId))
        {

        }
    }
}
