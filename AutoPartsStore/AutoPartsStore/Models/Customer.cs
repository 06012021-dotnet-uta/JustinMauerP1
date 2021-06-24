using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsStore.Models
{
    public class Customer
    {

        public int CustomerId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        [Required]
        public string email { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string password { get; set; }

        public int Store { get; set; }
    }
}
