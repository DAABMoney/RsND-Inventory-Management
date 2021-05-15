using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public string VINnumber { get; set; }
        [Required]
        public string Quantity { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }

    }
}
