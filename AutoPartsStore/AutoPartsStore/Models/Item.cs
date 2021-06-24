using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsStore.Models
{
    public class Item
    {
        public int PartId { get; set; }
        public int PartNumber { get; set; }
        public string Part { get; set; }
        public string PartDescription { get; set; }
        public double Price { get; set; }
        public string PartLocation
        {
            get; set;
        }
    }
}
