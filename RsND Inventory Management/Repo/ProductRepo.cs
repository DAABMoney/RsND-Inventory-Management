using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Repo
{
    
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _db;

        public ProductRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        

        public bool Create(Product entity)
        {
            _db.Products.Add(entity);
            return Save();
            
        }

        public bool Delete(Product entity)
        {
            _db.Products.Remove(entity);
            return Save();
        }

        public ICollection<Product> FindAll()
        {
           var products = _db.Products.ToList();
            return products;
        }

        public Product FindById(int id)
        {
            var products = _db.Products.Find(id);
            return products;
        }

        public bool isExists(int id)
        {
            var exists = _db.Products.Any(l => l.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Product entity)
        {
            _db.Products.Update(entity);
            return Save();
        }
    }
}
