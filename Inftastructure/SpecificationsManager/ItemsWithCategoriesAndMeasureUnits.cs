using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.SpecificationsManager
{
    public class ItemsWithCategoriesAndMeasureUnits : SpecificationsManager<Item>
    {
        public ItemsWithCategoriesAndMeasureUnits()
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.MeasureUnit);


        }

        public ItemsWithCategoriesAndMeasureUnits(int id) 
            : base(x => x.Id ==id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.MeasureUnit);

        }
    }
}
