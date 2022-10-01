using Bakers.Model;
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

        Customer AddCustomer(Customer customer);


        void DeleteCustomer(int Id);

        Task<Customer> EditCustomer(int id, Customer customer);
    }
}
