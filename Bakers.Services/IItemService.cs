using Bakers.Model;
using Bakers.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bakers.Services
{
    public interface IItemService
    {



        List<Item> GetAllItem();

        Item GetItem(int Id);
       
        public Task<Show> AddItem(AddItem request);


        void DeleteItem(int Id);


        Task<Item> EditItem(int Id, Item item);
    }
}
