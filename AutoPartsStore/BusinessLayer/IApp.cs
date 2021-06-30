using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IApp
    {
        Task<bool> RegisterCustomerAsync(Customer c);
        Task<List<Customer>> CustomerListAsync();
        Task<Customer> FindCustomerAsync(string lastName, string password);
        Task<List<Store>> StoreListAsync();
        Task<List<Item>> ItemListAsync(Store store);
        Task<bool> ChangeStore(Store store, Customer cust);


    }
}
