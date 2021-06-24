using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Item
    {
        private int partId;
       
        [Key]
        public int PartId
        { 
            get
            {
                return partId;
            }
            set
            {
                partId = value;
            }
        
        }

        private int partNumber;

        public int PartNumber
        {
            get { return partNumber; }
            set { partNumber = value; }
        }

        private string part;

        public string Part
        {
            get { return part; }
            set { part = value; }
        }

        private string partDesc;

        public string PartDesc
        {   
            get { return partDesc; }
            set { partDesc = value; }
        }

        private Decimal price;

        public Decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private int store;

        public int Store
        {
            get { return store; }
            set { store = value; }
        }

    }
}
