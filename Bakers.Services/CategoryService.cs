using Bakers.DB;
using Bakers.Model;
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

        public Category AddCategory(Category category)
        {

            _Context.Category.Add(category);
            _Context.SaveChanges();
            return category;
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
            try
            {
                var listCategory =  _Context.Category.ToList();
                return listCategory;
            }
            catch(Exception )
            {
                return new List<Category>();
            }
        }

        public Category GetCategory(int Id)
        {
            return _Context.Category.FirstOrDefault(a => a.Id == Id);
        }
    }
}
