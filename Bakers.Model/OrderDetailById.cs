using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.Model
{
    public class OrderDetailById
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
         public OrderDetail Data { get; set; }

    }
}
