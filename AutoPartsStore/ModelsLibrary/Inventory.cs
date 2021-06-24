using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    [Keyless]
    public class Inventory
    {
        private int storeId;

        [ForeignKey("Store")]
        public int StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }

        private int partId;

        [ForeignKey("Item")]
        public int PartId
        {
            get { return partId; }
            set { partId = value; }
        }

        private Decimal price;

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private Decimal _value;

        public Decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
        public double InvPrive()
        {
            return (double)(quantity * price); 
        }
    }
}
