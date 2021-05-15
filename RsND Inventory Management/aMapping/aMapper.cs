using AutoMapper;
using RsND_Inventory_Management.Data;
using RsND_Inventory_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Mapping
{
    public class aMapper : Profile
    {
        public aMapper()
        {
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Staff, StaffVM>().ReverseMap();
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Supplier, SupplierVM>().ReverseMap();
            CreateMap<Invoice, InvoiceVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
        }
    }
}
