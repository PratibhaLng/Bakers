using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.Model
{
    public class OrderDetailUpdate
    {
      public int Id { get; set; }
        public int ItemId { get; set; }

        public int Quantity { get; set; }

    }
}
