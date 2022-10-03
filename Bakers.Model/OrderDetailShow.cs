using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.Model
{
    public class OrderDetailShow
    {
        public int CustomerId { get; set; }

        public int ItemId { get; set; }
       // [required]
        public int Quantity { get; set; }


        public decimal Cost { get; set; }

       // public decimal SubAmount { get; set; }

    }
  

}
