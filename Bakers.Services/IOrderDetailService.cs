using Bakers.Model;
using Bakers.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bakers.Services
{
    public interface IOrderDetailService
    {
        public Task<Show> OrderDetail(OrderDetailShow request);
        OrderDetail GetOrderDetail(int Id);
        List<OrderDetail> GetAllOrder();
       
        Task<Show> DeleteOrderDetail(int Id);
       
    }
}
