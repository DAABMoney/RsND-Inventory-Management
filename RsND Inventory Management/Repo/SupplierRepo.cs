using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Repo
{
    public class SupplierRepo : ISupplierRepo
    {
        private readonly ApplicationDbContext _db;

        public SupplierRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public bool Create(Supplier entity)
        {
            _db.Suppliers.Add(entity);
            return Save();
        }

        public bool Delete(Supplier entity)
        {
            _db.Suppliers.Remove(entity);
            return Save();
        }

        public ICollection<Supplier> FindAll()
        {
            var suppliers = _db.Suppliers.ToList();
            return suppliers;
        }

        public Supplier FindById(int id)
        {
            var suppliers = _db.Suppliers.Find(id);
            return suppliers;
        }

        public bool isExists(int id)
        {
            var exists = _db.Suppliers.Any(l => l.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Supplier entity)
        {
            _db.Suppliers.Update(entity);
            return Save();
        }
    }
}
