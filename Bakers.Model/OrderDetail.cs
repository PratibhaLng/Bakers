using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.Model
{
    public class OrderDetail
    {
       public int  Id { get; set; } 
        public int CustomerId { get; set; }

       public int  ItemId { get; set; }

       public int  Quantity { get; set; }
         

        public decimal Cost { get; set; }  

        public decimal SubAmount { get; set; }
        public decimal Discount { get; set; }

           public decimal Tax { get; set; }

           public decimal Amount { get; set; }

        public DateTime Createorder { get; set; }

        public bool IsCancelled { get; set; }

    }
}
