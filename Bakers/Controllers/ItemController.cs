using Bakers.Model;
using Bakers.Response;
using Bakers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakers.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _citem;

        public ItemController(IItemService citem)
        {
            _citem = citem;


        }



        [HttpGet]
        [Route("api/[controller]")]


        public IActionResult GetAllItem()
        {
            try
            {



                return Ok(_citem.GetAllItem());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

            }



        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItem request)
        {


            Show response = new Show();

            try
            {

                response = await _citem.AddItem(request);

            }

            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return Ok(response);

        }




        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            try
            {
                var resultId = _citem.GetItem(id);
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
       

        [HttpDelete]
        [Route("delete/Id")]
        public IActionResult DeleteItem(int Id)


        {
            try
            {
                var removeItem = _citem.GetItem(Id);
                if (removeItem == null)
                {



                    return NotFound($"Category With Id:{Id}  was not found");
                }

                {

                    _citem.DeleteItem(Id);
                    return Ok(removeItem);

                }
            }

            catch (Exception ee)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ee);
            }
        }





        [HttpPut]
        [Route("Edit/Id")]
        public IActionResult EditItem(int Id, Item item)

        {

            try
            {

                var existingItem = _citem.GetItem(Id);

                if (existingItem != null)
                {
                    _citem.EditItem(Id, item);
                    return Ok(item);
                }

                return StatusCode(StatusCodes.Status400BadRequest, $"Item Id {Id} not found");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);


            }
        }
    }
}
