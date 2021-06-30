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
        /// <summary>
        /// Returns a list of all customers in the Database.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list of all the stores
        /// </summary>
        /// <returns></returns>
        public async Task<List<Store>> StoreListAsync()
        {
            List<Store> storeList = null;

            try
            {
                storeList = _context.Stores.ToList();
            }
            catch (ArgumentNullException ex)
            {
                // Log

            }

            return storeList;
        }

        /// <summary>
        /// Returns customer if found or null if no customer matches the parameters.
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Customer> FindCustomerAsync(string lastName, string password)
        {
            Customer cust;

            try
            {
                cust = _context.Customers.Where(x => x.LastName == lastName).Single();
                if (cust.Password == password)
                    return cust;
                else
                    return null;
            }
            catch (Exception ex)
            {
                cust = null;
            }
            return cust;
        }
        
        /// <summary>
        /// Returns all items for a specified store.
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task<List<Item>> ItemListAsync(Store store)
        {
            List<Item> storeItems = _context.Items.Where(x => x.Store == store.StoreId).ToList();

            return storeItems;
        }

        public async Task<bool> ChangeStore(Store store, Customer cust)
        {
            bool changed = false;
            Customer custChange;
            try
            {
                custChange = _context.Customers.Where(x => x.CustomerId == cust.CustomerId).Single();
                custChange.Store = store.StoreId;
                _context.SaveChanges();
                changed = true;

            }
            catch(Exception ex)
            {
                changed = false;
            }

            return changed;
        }
    }
}
