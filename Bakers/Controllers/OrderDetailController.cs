using Bakers.Model;
using Bakers.Response;
using Bakers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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


        [Produces("application/json")]
        //[HttpGet]
        //public async Task<IActionResult> OrderDetailById(int Id)
        //{
        //    Show response = new Show();
        //    try
        //    {
        //        response = await _cOrder.OrderDetailById(Id);

        //    }
        //    catch (Exception ex)
        //    {

        //        response.IsSuccess = false;
        //        response.Message = "Exception Occurs : " + ex.Message;

        //    }
        //    return Ok(response);

        //}

        [HttpGet("{id:int}")]
        public IActionResult GetOrderDetail(int id)
        {
            try
            {
                var resultId = _cOrder.GetOrderDetail(id);
                if (resultId == null)
                {
                    return NotFound();
                }
                return Ok(resultId);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

            }

        }


            [HttpGet]
        [Route("api/[controller]")]


        public IActionResult GetAllOrder()
        {

            try
            {

                return Ok(_cOrder.GetAllOrder());
            }

            catch (Exception ee)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ee);

            }

        }





        [HttpDelete]
        [Route("delete/Id")]
        public  async Task<IActionResult> DeleteOrderDetail(int Id)
        {
            Show response = new Show();
            
            try
            {
                

               
                   response=await _cOrder.DeleteOrderDetail(Id);
                
                   return Ok(response);
                
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












