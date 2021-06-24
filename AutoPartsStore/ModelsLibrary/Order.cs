using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Order
    {
        private int orderId;

        [Key]
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        private int customerId;
        [ForeignKey("Customer")]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        private int storeId;

        [ForeignKey("Store")]
        public int StoreId
        {
            get { return storeId; }
            set { storeId = value; }
        }

        private int totalItems;

        public int TotalItems
        {
            get { return totalItems; }
            set { totalItems = value; }
        }

        private Decimal totalPrice;

        public Decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        private DateTime orderDate;

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }
            
    }
}
