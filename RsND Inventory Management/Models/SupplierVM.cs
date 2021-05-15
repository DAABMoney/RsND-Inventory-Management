using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Models
{
    public class SupplierVM
    {
        public int Id { get; set; }
        [Display(Name = "Supplier Name")]
        [Required]
        public string SupplierName { get; set; }
        
        public string Address { get; set; }
        [Display(Name = "Contact Number")]
        [Required]
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        
    }
}
