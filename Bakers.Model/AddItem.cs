using System;
using System.Collections.Generic;
using System.Text;

namespace Bakers.Model
{
    public class AddItem
    {
        public string ItemName { get; set; }

        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
}
