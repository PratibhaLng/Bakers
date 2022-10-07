using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakers.Model
{
    public class AddItem
    {
        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }
        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
