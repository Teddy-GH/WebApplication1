using Domain.Entities;
using Domain.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.SpecificationsManager
{
   public class ItemSpecParams
    {
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? CateoryId { get; set; }

        public int? MeasureUnitId { get; set; }

        public string Sort { get; set; }

        private string _search;

        public string Search  
        {
            get => _search; 
            set => _search = value.ToLower();
        }

    }
}
