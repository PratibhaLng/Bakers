using Bakers.DB;
using Bakers.Model;
using Bakers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakers.Services
{
    public class CustomerService : ICustomerService
    {
        private BakersDbcontext _Context;
        public CustomerService(BakersDbcontext Context)
        {
            _Context = Context;
        }
        public async Task<Show> AddCustomer(AddCustomer request)
        {
            Show response = new Show();

            try
            {

                Customer customer = new Customer();
                customer.Name = request.Name;
                customer.Address = request.Address;
                customer.PhoneNo = request.PhoneNo;
                response.IsSuccess = true;
                response.Message = "Data Successfully Inserted";
                _Context.Customers.Add(customer);
                await _Context.SaveChangesAsync();


            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;
        }
        public void DeleteCustomer(int Id)
        {

            var result = _Context.Customers.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _Context.Customers.Remove(result);
                _Context.SaveChanges();


            }
        }

        public async Task<Customer> EditCustomer(int id, Customer customer)
        {


            var _temp = GetCustomer(id);
            if (_temp != null)
            {
                _temp.Name = customer.Name;
                _temp.Address = customer.Address;
                _temp.PhoneNo = customer.PhoneNo;
                await _Context.SaveChangesAsync();
                return _temp;

            }
            throw new Exception("Customer Id not found");

        }





        public List<Customer> GetAllCustomer()
        {
            return _Context.Customers.ToList();
        }

        public Customer GetCustomer(int Id)
        {
            return _Context.Customers.FirstOrDefault(x => x.Id == Id);

        }

    }
}
