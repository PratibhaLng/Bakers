using Bakers.DB;
using Bakers.Model;
using Bakers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakers.Services
{
    public class CategoryService : ICategoryService
    {

        private BakersDbcontext _Context;
        public CategoryService(BakersDbcontext Context)
        {
            _Context = Context;
        }

       
        public async Task<Show> AddCategory(AddCategory request)
        {
            Show response = new Show();

            try
            {

                Category category = new Category();
                category.Name = request.Name;
                

                response.IsSuccess = true;
                response.Message = "Data Successfully Inserted";
                _Context.Category.Add(category);
                await _Context.SaveChangesAsync();


            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;
        }


        public void DeleteCategory(int Id)
        {



            var result = _Context.Category.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _Context.Category.Remove(result);
                _Context.SaveChanges();


            }

        }

        public async Task<Category> EditCategory(int Id, Category category)

        {

            var _temp = GetCategory(Id);
            if (_temp != null)
            {
                _temp.Name = category.Name;

                await _Context.SaveChangesAsync();
                return _temp;

            }
            return null;

        }


        public List<Category> GetAllCategory()
        {
            
                var listCategory =  _Context.Category.ToList();
                return listCategory;
            
            
        }

        public Category GetCategory(int Id)
        {
            return _Context.Category.FirstOrDefault(a => a.Id == Id);
        }
    }
}
