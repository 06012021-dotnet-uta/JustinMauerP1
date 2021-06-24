using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Customer
    {
        
        private int customerId;

        [Key]
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
    
        private string _firstName;

        [Required]
        [MaxLength(30)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private string _lastName;

        [Required]
        [MaxLength(30)]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        private string _phoneNumber;
        
        
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        
        }

        private string _email;
        
        public string Email
        { 
            get
            {
                return _email;
            }
            
            set
            {
                _email = value;
            }
        
        }
        public string _city;
        
        public string City
        { 
            get
            {
                return _city;
            }
            
            set
            {
                _city = value;
            }
        
        }
        private string _state;
        
        public string State
        { 
            get
            {
                return _state;
            }
            
            set
            {
                _state = value;
            }
        
        }
        private string _password;
        
        public string Password
        { 
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        
        }

        public int _store;
        public int Store
        { 
            get
            {
                return _store;
            }
            
            set
            {
                _store = value;
            }
        
        }

        private int carYear;
        [Required]
        [MaxLength(4)]
        [Range(1980,2021)]
        public int CarYear
        {
            get { return carYear; }
            set { carYear = value; }
        }

        private string carMake;

        [Required]
        public string CarMake
        {
            get { return carMake; }
            set { carMake = value; }
        }

        private string carModel;

        [Required]
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }
            

    }
}
