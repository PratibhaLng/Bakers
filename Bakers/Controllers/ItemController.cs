using Bakers.Model;
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
        [Route("api/[controller]")]

        public IActionResult AddItem(Item item)
        {
            _citem.AddItem(item);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Host + HttpContext.Request.Path + "/" + item.Id, item);




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



        //[HttpGet("{id:int}")]
        //public async ActionResult GetItem(int id)
        //{
        //    try
        //    {
        //         await _citem.Items
        //            .Include(c => c.Category)
        //            .Where(c => c.Id == Id)
        //            .FirstorDefaultAsync();
        //        ;

        //        if (resultId == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(resultId);

        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError);

        //    }

       }

        [HttpDelete]
        [Route("delete/Id")]
        public IActionResult DeleteItem(int Id)


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





        [HttpPut]
        [Route("Edit/Id")]
        public IActionResult EditItem(int Id, Item item)

        {
            //var existingCategory = _ccategory.GetCategory(id);
            // if (existingCategory != null)
            //   category.Id = existingCategory.Id;
            _citem.EditItem(Id, item);
            return Ok(item);
        }

    
    }
}
