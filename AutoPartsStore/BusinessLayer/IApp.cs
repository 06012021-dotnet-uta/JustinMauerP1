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
    }
}
