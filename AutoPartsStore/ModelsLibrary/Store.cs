using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Store
    {
        private int storeId;

        [Key]
        public int StoreId          
        {
            get { return storeId; }
            set { storeId = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public Store()
        {

        }

    }
}
