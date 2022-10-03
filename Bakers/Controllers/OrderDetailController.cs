using Bakers.Model;
using Bakers.Response;
using Bakers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bakers.Controllers
{


    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _cOrder;
        public OrderDetailController(IOrderDetailService cOrder)
        {
            _cOrder = cOrder;
        }


        [HttpPost]
        public async Task<IActionResult> OrderDetail(OrderDetailShow request)
        {


            Show response = new Show();

            try
            {


                response = await _cOrder.OrderDetail(request);



            }

            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return Ok(response);

        }

        [HttpGet("GetOrderDetails/{Id}")]

        [HttpGet]
        public async Task<IActionResult> OrderDetailById([FromQuery] int Id)
        {
            OrderDetailById response = new OrderDetailById();
            try
            {
                response = await _cOrder.OrderDetailById(Id);

            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return Ok(response);

        }



        [HttpPut]
        public async Task<IActionResult> OrderDetailUpdate(OrderDetailUpdate request)
        {
            Show response = new Show();
            try
            {
                response = await _cOrder.OrderDetailUpdate(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return Ok(response);
        }


    }




}










// public IActionResult Index()
//{
//  return View();
//}


