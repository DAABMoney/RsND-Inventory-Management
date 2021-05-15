using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Models
{
    public class InvoiceVM
    {
        public int Id { get; set; }
        
        public DateTime? Date { get; set; }

        [Required]
        public string Value { get; set; }
       
      
    }
}
