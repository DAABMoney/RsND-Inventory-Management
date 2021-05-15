using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Repo
{
    public class StaffRepo : IStaffRepo
    {
        private readonly ApplicationDbContext _db;

        public StaffRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(Staff entity)
        { 
            _db.Staffs.Add(entity);
            return Save();
           
        }

        public bool Delete(Staff entity)
        {
            _db.Staffs.Remove(entity);
            return Save();
        }

        public ICollection<Staff> FindAll()
        {
            var staffs = _db.Staffs.ToList();
            return staffs;
        }

        public Staff FindById(int id)
        {
            var staffs = _db.Staffs.Find(id);
            return staffs;
        }

        public bool isExists(int id)
        {
            throw new NotImplementedException();
        }


        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(Staff entity)
        {
            _db.Staffs.Update(entity);
            return Save();
        }
    }
}
