using Bakers.DB;
using Bakers.Model;
using Bakers.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakers.Services
{


    public class OrderDetailService : IOrderDetailService
    {

        private BakersDbcontext _Context;
        public OrderDetailService(BakersDbcontext Context)
        {
            _Context = Context;
        }

        public async Task<OrderDetailById> OrderDetailById(int Id)
        {

            OrderDetailById response = new OrderDetailById();
            response.IsSuccess = true;
            response.Message = "Fetched Data successfully";
            try
            {
                response.Data = await _Context.OrderDetail

                          .Where(x => (x.Id == Id))
                          .Include(a => a.CustomerId)
                          .Include(a => a.ItemId)
                         .FirstOrDefaultAsync();
                if (response.Data == null)
                {
                    response.Message = "Invalid ID Please Enter Valid Id";
                }

            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;


        }

        public async Task<Show> OrderDetail(OrderDetailShow request)
        {
            Show response = new Show();

            try
            {
                response.IsSuccess = true;
                response.Message = "Data Successfully Inserted";
                
                await _Context.SaveChangesAsync();


            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;
        }

        public Task<IActionResult> OrderDetail(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Show> OrderDetailUpdate(OrderDetailUpdate request)
        {
            Show response = new Show();
            try
            {
                response.IsSuccess = true;
                response.Message = "Data Successfully Updated";



                var result = await _Context.OrderDetail.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (result != null)


                    _Context.OrderDetail.Update(result);
                _Context.SaveChanges();




            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;
        }


        public List<OrderDetail> GetAllOrder()
        {

            var myorder = _Context.OrderDetail

                          .Include(a => a.CustomerId)
                          .Include(a => a.ItemId)
                         .ToList();
            return myorder;
        }

        public void DeleteOrderDetail(int Id)
        {



            var result = _Context.OrderDetail.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _Context.OrderDetail.Remove(result);
                _Context.SaveChanges();


            }


        }

        //public bool isDiscountValid()
        //{  
            
        //    var result = _Context.OrderDetail.SubAmount.where(a => a.Id == CustomerId).FirstOrDefault();
        //if (result>500)
        //        return true;
        //}

    }
}
   
