using Bakers.Model;
using Bakers.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bakers.Services
{
    public interface ICustomerService
    {

        List<Customer> GetAllCustomer();

        Customer GetCustomer(int Id);

        public Task<Show> AddCustomer(AddCustomer request);

        void DeleteCustomer(int Id);

        Task<Customer> EditCustomer(int id, Customer customer);
    }
}
