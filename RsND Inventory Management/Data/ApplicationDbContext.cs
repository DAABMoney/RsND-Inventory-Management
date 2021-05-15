using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RsND_Inventory_Management.Models;

namespace RsND_Inventory_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RsND_Inventory_Management.Models.StaffVM> StaffVM { get; set; }
        public DbSet<RsND_Inventory_Management.Models.SupplierVM> SupplierVM { get; set; }
        public DbSet<RsND_Inventory_Management.Models.OrderVM> OrderVM { get; set; }
        public DbSet<RsND_Inventory_Management.Models.ProductVM> ProductVM { get; set; }
        public DbSet<RsND_Inventory_Management.Models.InvoiceVM> InvoiceVM { get; set; }
        public DbSet<RsND_Inventory_Management.Models.CustomerVM> CustomerVM { get; set; }
    }
}
