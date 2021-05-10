using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
 public  class ResponseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public float Quantity { get; set; }
        public string Category { get; set; }
        public string MeasureUnit { get; set; }
    }
}
