using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bakers.Model
{
    public class AddCustomer
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string PhoneNo { get; set; }




    }
}
