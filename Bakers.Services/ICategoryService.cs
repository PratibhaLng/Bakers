using Bakers.Model;
using Bakers.Response;
//using Bakers.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bakers.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();

        Category GetCategory(int Id);

        
        public Task<Show> AddCategory(AddCategory request);

        void DeleteCategory(int Id);


        Task<Category> EditCategory(int id, Category category);
    }

}

