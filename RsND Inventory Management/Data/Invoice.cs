using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Data
{
    public class Invoice
    {
        internal DateTime DateCreated;

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Value { get; set; }
        [ForeignKey("CustomerID")]
        public  Customer Customer{ get; set; }
        public int CustomerID { get; set; }

    }
}
