using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Repo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepo(ApplicationDbContext db)
        {
            _db = db;
        }
          

        public bool Create(Customer entity)
        {
            _db.Customers.Add(entity);
            return Save();
        }

        public bool Delete(Customer entity)
        {
            _db.Customers.Remove(entity);
            return Save();
        }

        public ICollection<Customer> FindAll()
        {
            var customers = _db.Customers.ToList();
            return customers;
        }

        public Customer FindById(int id)
        {
            var customers = _db.Customers.Find(id);
            return customers;
        }

        public bool isExists(int id)
        {
            var exists = _db.Customers.Any(l => l .Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Customer entity)
        {
            _db.Customers.Update(entity);
            return Save();
        }
    }
}
