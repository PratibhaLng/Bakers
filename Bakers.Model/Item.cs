using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakers.Model
{
    public class Item
    {

       
        public int Id { get; set; }
        
        public string ItemName { get; set; }
        
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

    }
}
