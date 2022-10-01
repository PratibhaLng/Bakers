﻿using Bakers.Model;
//using Bakers.Response;
using Bakers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

                }


            }
            [HttpPost]
            [Route("api/[controller]")]

            public IActionResult AddCategory(Category category)
            {
                _categoryservice.AddCategory(category);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.Id, category);




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
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

                }

            }

            [HttpDelete]
            [Route("delete/Id")]
            public IActionResult DeleteCategory(int Id)


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





            [HttpPut]
            [Route("Edit/Id")]
            public ActionResult  EditCategory(int Id, Category category)

            {
                //var existingCategory = _ccategory.GetCategory(id);
                // if (existingCategory != null)
                //   category.Id = existingCategory.Id;
                _categoryservice.EditCategory(Id, category);
                return Ok(category);
            }

            // public IActionResult Index()
            //{
            //  return View();
            //}
        }
}