using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakers.Model
{
    public  class AddCategory
    {
        [Required]
        [StringLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }    

    }
}
