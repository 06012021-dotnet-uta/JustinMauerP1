using Microsoft.EntityFrameworkCore;
using ModelsLibrary;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class App : IApp
    {
        private readonly AppStoreDb _context;

        public App()
        {

        }
        
        //register the context in startup.cs
        public App(AppStoreDb context)
        {
            this._context = context;
        }

        /// <summary>
        /// Saves a new customer to the Db.
        /// If the save was unsuccessful, returns false,
        /// it returns true otherwise.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task<bool> RegisterCustomerAsync(Customer c)
        {
            // create a try/catch to save customer
            await _context.Customers.AddAsync(c);
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
                return false;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"There was a problem updating the Db => {ex.InnerException}");
                return false;
            }



            return true;

        }

        public async Task<List<Customer>> CustomerListAsync()
        {
            List<Customer> custList = null;

            try
            {
                custList = _context.Customers.ToList();
            }
            catch(ArgumentNullException ex)
            {
                // Log

                Console.WriteLine($"There was a problem creating a customer list");
            }
            
            

            return custList;
        }

    }
}
