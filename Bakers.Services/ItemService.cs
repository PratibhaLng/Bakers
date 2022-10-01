using Bakers.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static Bakers.Services.ItemService;
using System.Threading.Tasks;
using Bakers.DB;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Bakers.Services
{
  
    
        public class ItemService : IItemService
        {
            private BakersDbcontext _Context;
            public ItemService(BakersDbcontext Context)
            {
                _Context = Context;
            }

            public Item AddItem(Item item)
            {
                //  category.Id = Id;
                _Context.Items.Add(item);
                _Context.SaveChanges();
            
                return item;
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


            public async Task<Item> EditItem(int Id, Item item)
            {


                var _temp = GetItem(Id);
                if (_temp != null)
                {
                    _temp.ItemName = item.ItemName;
                    _temp.Quantity = item.Quantity;
                    _temp.Price = item.Price;
                    _temp.CategoryId = item.CategoryId;
                    await _Context.SaveChangesAsync();
                    return _temp;

                }
                return null;

            }



            public List<Item> GetAllItem()
            {

                var myitem = _Context.Items.ToList();
                return myitem;
            }



            public Item GetItem(int Id)
            {
                return _Context.Items.FirstOrDefault(a => a.Id == Id);



            }

        }
}
