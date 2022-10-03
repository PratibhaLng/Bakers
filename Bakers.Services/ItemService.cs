using Bakers.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static Bakers.Services.ItemService;
using System.Threading.Tasks;
using Bakers.DB;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Bakers.Response;

namespace Bakers.Services
{
  
    
        public class ItemService : IItemService
        {
            private BakersDbcontext _Context;
            public ItemService(BakersDbcontext Context)
            {
                _Context = Context;
            }
        public async Task<Show> AddItem(AddItem request)
        {
            Show response = new Show();

            try
            {

                Item item = new Item();
                item.ItemName = request.ItemName;
                item.Price = request.Price;
                item.CategoryId = request.CategoryId;

                response.IsSuccess = true;
                response.Message = "Data Successfully Inserted";
               _Context.Items.Add(item);
                await _Context.SaveChangesAsync();


            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occurs : " + ex.Message;

            }
            return response;
        }

       


            public void DeleteItem(int Id)
            {



                var result = _Context.Items.Where(a => a.Id == Id).FirstOrDefault();
                if (result != null)
                {

                    _Context.Items.Remove(result);
                    _Context.SaveChanges();


                }

            }

        public async Task<Item> EditItem(int id, Item item)
        {


            var _temp = GetItem(id);
            if (_temp != null)
            {
                _temp.ItemName = item.ItemName;
                 _temp.Price= item.Price;
                await _Context.SaveChangesAsync();
                return _temp;

            }
            return null;

        }
        //public  Task<Item> EditItem(int Id, Item item)
        //    {


        //        var _temp = GetItem(Id);
        //        if (_temp != null)
        //        {
        //            _temp.ItemName = item.ItemName;
        //       //  _temp.Quantity = item.Quantity;
        //            _temp.Price = item.Price;
        //           // _temp.CategoryId = item.CategoryId;
        //             _Context.SaveChanges();
        //            return _temp;

        //        }
        //        return null;

        //    }

        public List<Item> GetAllItem()
        {

            var myitem = _Context.Items.ToList();
            return myitem;
        }



        public Item GetItem(int Id)
        {
            return _Context.Items.FirstOrDefault(a => a.Id == Id);



        }

       

        //    public async Task<IActionResult> GetAllItem()
        //{


        //    {

        //        var itemList= await _Context.Items
        //        .Include(x=>x.CategoryId)
        //        .ToListAsync();

        //    }



        //public async Task<ActionResult> GetItem(int Id)
        //    {

        //    var myitem = await _Context.Items
        //        .Include(c => c.CategoryId)
        //        .Where(c => c.Id == Id)
        //        .FirstOrDefaultAsync();
        //    return myitem;



        //}


    }
}
