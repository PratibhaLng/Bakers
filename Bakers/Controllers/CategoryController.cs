using Bakers.Model;
using Bakers.Response;
//using Bakers.Response;
using Bakers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bakers.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryservice;

        public CategoryController(ICategoryService ccategory)
        {
            _categoryservice = ccategory;


        }



        [HttpGet]
        [Route("api/[controller]")]


        public IActionResult GetAllCategory()
        {
            try
            {

                return Ok(_categoryservice.GetAllCategory());
            }
            catch (Exception ee)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ee);

            }


        }
        [HttpPost]
        [Route("api/[controller]")]


        public async Task<IActionResult> AddCategory(AddCategory request)
        {


            Show response = new Show();

            try
            {

                response = await _categoryservice.AddCategory(request);

            }

            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return Ok(response);

        }





        [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var resultId = _categoryservice.GetCategory(id);
                if (resultId == null)
                {
                    return NotFound();
                }
                return Ok(resultId);

            }
            catch (Exception ee)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ee);

            }

        }

        [HttpDelete]
        [Route("delete/Id")]
        public IActionResult DeleteCategory(int Id)


        {

            try
            {
                var removeCategory = _categoryservice.GetCategory(Id);
                if (removeCategory == null)
                {



                    return NotFound($"Category With Id:{Id}  was not found");
                }

                {

                    _categoryservice.DeleteCategory(Id);
                    return Ok(removeCategory);

                }
            }

            catch (Exception ee)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ee);


            }
        }





        [HttpPut]
        [Route("Edit/Id")]
        public ActionResult EditCategory(int Id, Category category)
             {

            try
            {
                var existingCategory = _categoryservice.GetCategory(Id);
                
                  if (existingCategory != null)
                {
                     _categoryservice.EditCategory(Id,category);
                    return Ok(category);
                }

                return StatusCode(StatusCodes.Status400BadRequest, $"Category Id {Id} not found");

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);


            }


        }

            // public IActionResult Index()
            //{
            //  return View();
            //}
        }
}
