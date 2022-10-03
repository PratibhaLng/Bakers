using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.Model
{
    public  class GetAllItemsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<Item> data{ get; set; }


    }
}
