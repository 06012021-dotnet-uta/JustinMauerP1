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

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(30)]
        [Display(Name ="First Name")]
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

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
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
        
        [Display(Name ="Phone")]
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
        
        [Display(Name ="Email")]
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
        
        [Display(Name ="City")]
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
        
        [Display(Name ="State")]
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
        
        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
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

        [Display(Name ="Store")]
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
        /*[MaxLength(4)]
        [Range(1980,2021)]*/

        [Required(ErrorMessage = "Year is required")]
        [Display(Name ="Year")]
        public int CarYear
        {
            get { return carYear; }
            set { carYear = value; }
        }

        private string carMake;

        [Required(ErrorMessage = "Make is required")]
        [Display(Name ="Make")]
        public string CarMake
        {
            get { return carMake; }
            set { carMake = value; }
        }

        private string carModel;

        [Required(ErrorMessage = "Model is required")]
        [Display(Name ="Model")]
        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }

        public Customer()
        {

        }

        public Customer(string firstName, string lastName,
                        string phoneNumber, string email, string city,
                        string state, string password, int store,
                        int carYear, string carMake, string carModel)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _email = email;
            _city = city;
            _state = state;
            _password = password;
            _store = store;
            this.carYear = carYear;
            this.carMake = carMake;
            this.carModel = carModel;
        }
    }
}
