using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLibrary;

namespace AutoPartsStore.Models
{
    public class CustomerCheckout
    {
        public IEnumerable<ModelsLibrary.Item> itemList { get; set; }
        public int StoreNum {get; set;}
        public Customer cust { get; set; }

    }
}
