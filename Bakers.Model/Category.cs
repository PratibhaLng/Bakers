using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakers.Model
{
    public class Category
    {

        public int Id { get; set; }
        
        public string Name { get; set; }

    }
}
