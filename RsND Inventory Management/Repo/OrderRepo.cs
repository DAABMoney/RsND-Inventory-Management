using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _db;

        public OrderRepo(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool Create(Order entity)
        {
            _db.Orders.Add(entity);
            return Save();
        }

        public bool Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            return Save();
        }

        public ICollection<Order> FindAll()
        {
            var orders = _db.Orders.ToList();
            return orders;
        }

        public Order FindById(int id)
        {
            var orders = _db.Orders.Find(id);
            return orders;
        }

        public bool isExists(int id)
        {
            var exists = _db.Orders.Any(l => l.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Order entity)
        {
            _db.Orders.Update(entity);
            return Save();
        }
    }
}
