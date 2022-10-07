using Bakers.Model;
using Bakers.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bakers.Services;

//namespace Bakers.Controllers
//{
    //[Route("api/[controller]/[Action]")]
    //[ApiController]
    //public class OrderController :   ControllerBase
    //{

       
    
    //    private readonly IOrder _ccOrder;
    //    public OrderController(IOrder ccOrder)
    //    {
    //        _ccOrder = ccOrder;
    //    }


    //    [HttpPost]
    //    public async Task<IActionResult> OrderCreate(OrderCreate request)
    //    {


    //        Show response = new Show();

    //        try
    //        {


    //            response = await _ccOrder.OrderCreate(request);



    //        }

    //        catch (Exception ex)
    //        {

    //            response.IsSuccess = false;
    //            response.Message = "Exception Occurs : " + ex.Message;

    //        }
    //        return Ok(response);

    //    }



        //    public IActionResult Index()
        //    {
        //        return View();
    //    //    }
    //    }
    //}
