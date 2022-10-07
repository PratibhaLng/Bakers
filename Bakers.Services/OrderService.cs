using Bakers.DB;
using Bakers.Model;
using Bakers.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Bakers.Services
//{
//    public class OrderService: IOrder
//    {

//        private BakersDbcontext _Context;
//        public OrderService(BakersDbcontext Context)
//        {
//            _Context = Context;
//        }
   
//public async Task<Show> OrderCreate(OrderCreate request)
//        {
           
//            Show response = new Show();

//            try
//            {
//                Order order = new Order();
                

//                var result = await _Context.OrderDetail.Where(x => x.Id == request.OrderNumber).FirstOrDefaultAsync();
//                decimal SubAmount  = result.SubAmount;

//                decimal discount = 0, tax = 0, Total = 0, Amount = 0, taxAmount = 0;
//                //orderDetail.Cost = item.Price * orderDetail.Quantity;
//              //  order.SubAmount = _Context.OrderDetail.Where(c => c.CustomerId == result.CustomerId).Sum(x => x.Cost);

//                if (SubAmount > 1000 || SubAmount < 1500)
//                {
//                    discount = Decimal.Multiply((decimal)0.001, SubAmount);

//                }
//                else
//                if (SubAmount > 1500 || SubAmount < 2500)
//                {

//                    discount = Decimal.Multiply((decimal)2.5, SubAmount);


//                }
//                else
//                if (SubAmount > 2500)
//                {

//                    discount = Decimal.Multiply((decimal)4, SubAmount);


//                }

//                if (SubAmount < 1000)
//                {
//                    Amount = SubAmount;


//                }
//                Total = Decimal.Subtract(SubAmount, discount);
//                if (Total > 1500)
//                    tax = tax = (decimal)0.12;
//                taxAmount = Decimal.Multiply(tax, Total);
//                Amount = decimal.Add(Total, taxAmount);

//                order.Discount = discount;
//                order.Tax = taxAmount;
//                order.Amount = Amount;



//                response.IsSuccess = true;
//                response.Message = "Data Successfully Inserted";
//                _Context.Order.Add(order);
//                order.OrderDate = DateTime.Now;
//                await _Context.SaveChangesAsync();



//            }

//            catch (Exception ex)
//            {
//                response.IsSuccess = false;
//                response.Message = "Exception Occurs : " + ex.Message;

//            }
//            return response;
//        }


//    }
//}
