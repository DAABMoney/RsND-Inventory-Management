using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Repo
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepo(ApplicationDbContext db)
        {
            _db = db;
        }

       
        public object Create(Invoice entity)
        {
            _db.Invoices.Add(entity);
            return Save();
        }

        public bool Delete(Invoice entity)
        {
            _db.Invoices.Remove(entity);
            return Save();
        }

        public ICollection<Invoice> FindAll()
        {
            var invoices = _db.Invoices.ToList();
            return invoices;
        }

        public Invoice FindById(int id)
        {
            var invoices = _db.Invoices.Find(id);
            return invoices;
        }

        public bool isExists(int id)
        {
            var exists = _db.Invoices.Any(l => l.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Invoice entity)
        {
            _db.Invoices.Update(entity);
            return Save();
        }

        bool IRepoBase<Invoice>.Create(Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
