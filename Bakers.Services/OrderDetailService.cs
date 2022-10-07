using Bakers.DB;
using Bakers.Model;
using Bakers.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        //public async Task<Show> OrderDetailById(int Id)
        //         {

        //    Show response = new Show();

        //    try { 
        //    response.IsSuccess = true;
        //    response.Message = "Fetched Data successfully";


        //       var result=  await _Context.OrderDetail
        //                  .Where(x => (x.Id == Id))
        //                 .FirstOrDefaultAsync();

        //        if (result == null)
        //        {
        //            response.Message = "Invalid ID Please Enter Valid Id";
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        response.IsSuccess = false;
        //        response.Message = "Exception Occurs : " + ex.Message;

        //    }
        //    return response;


        //}


            public async Task<Show> OrderDetail(OrderDetailShow request)
        {
            Show response = new Show();

            try
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ItemId = request.ItemId;
                orderDetail.Quantity = request.Quantity;
                orderDetail.CustomerId = request.CustomerId;

                var item = await _Context.Items.Where(x => x.Id == request.ItemId).FirstOrDefaultAsync();
                decimal discount = 0, tax = 0, Total = 0, Amount = 0, taxAmount = 0;
                orderDetail.Cost = item.Price * orderDetail.Quantity;
                orderDetail.SubAmount = _Context.OrderDetail.Where(c => c.CustomerId == request.CustomerId).Sum(x => x.Cost);
                if (orderDetail.SubAmount > 1000 || orderDetail.SubAmount < 1500)
                {
                    discount = Decimal.Multiply((decimal)0.001, orderDetail.SubAmount);

                }
                else
                if (orderDetail.SubAmount > 1500 || orderDetail.SubAmount < 2500)
                {

                    discount = Decimal.Multiply((decimal)2.5, orderDetail.SubAmount);


                }
                else
                if (orderDetail.SubAmount > 2500)
                {

                    discount = Decimal.Multiply((decimal)4, orderDetail.SubAmount);


                }

                if (orderDetail.SubAmount < 1000)
                {
                    Amount = orderDetail.SubAmount;


                }
                Total = Decimal.Subtract(orderDetail.SubAmount, discount);
                if (Total > 1500)
                    tax = tax = (decimal)0.12;
                taxAmount = Decimal.Multiply(tax, Total);
                Amount = decimal.Add(Total, taxAmount);

                orderDetail.Discount = discount;
                orderDetail.Tax = taxAmount;
                orderDetail.Amount = Amount;





                response.IsSuccess = true;
                response.Message = "Data Successfully Inserted";
                _Context.OrderDetail.Add(orderDetail);
                orderDetail.Createorder = DateTime.Now;
                await _Context.SaveChangesAsync();



            }


            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;
        }


        public OrderDetail GetOrderDetail(int Id)
        {
            return _Context.OrderDetail.FirstOrDefault(a => a.Id == Id);



        }

        public List<OrderDetail> GetAllOrder()
        {

            var myorder = _Context.OrderDetail.ToList();

            return myorder;
        }


        public async Task<Show> DeleteOrderDetail(int id)
        {
            Show response = new Show();
            try { 
            


            var orderDetail = _Context.OrderDetail.Where(a => a.Id == id).FirstOrDefault();




            if (orderDetail != null)
                {
                    //OrderDetail orderDetail = new OrderDetail();

                    //DateTime CancelDate = DateTime.Now;
                    //System.TimeSpan eTime = order.Subtract(CancelDate);
                    //var elapsedTime = eTime.TotalMinutes;

                    if ((DateTime.Now - orderDetail.Createorder).Minutes < 5)
                    {
                        response.IsSuccess = true;
                        response.Message = "Record deleted successfully";
                        orderDetail.IsCancelled = true;

                        _Context.OrderDetail.Update(orderDetail);
                        await _Context.SaveChangesAsync();



                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.Message = "Time over to cancel";
                    }
                    }
                }



            
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;

        }
    }
}
   
