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

        List<OrderDetail> GetAllOrder();
        //Task<IActionResult> OrderDetail(int Id);

       public Task<Show>OrderDetailUpdate(OrderDetailUpdate request);
        public Task<OrderDetailById>OrderDetailById(int Id);
        void DeleteOrderDetail(int Id);
       // public bool isDiscountValid()
    }
}
