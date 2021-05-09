using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public float Quantity { get; set; }
        public Category Category { get; set; }
        public int CategoryId {get; set;}
        public MeasureUnit MeasureUnit { get; set; }
        public int MeasureUnitId { get; set; }

    }
}
