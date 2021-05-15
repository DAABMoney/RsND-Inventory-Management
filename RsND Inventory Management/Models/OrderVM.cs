using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        [Display(Name = "Order Number")]
        [Required]
        public string OrderNumber { get; set; }
        [Display(Name = "VIN Number")]
        [Required]
        public string VINnumber { get; set; }
        [Required]
        public string Quantity { get; set; }
        
    }
}
