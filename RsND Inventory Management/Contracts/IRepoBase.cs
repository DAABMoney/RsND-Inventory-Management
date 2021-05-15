using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Contracts
{
    public interface IRepoBase<R> where R : class
    {
        ICollection<R> FindAll();
        R FindById(int id);
        bool isExists(int id);
        bool Create (R entity);
        bool Update(R entity);
        bool Delete(R entity);
        bool Save();
    }
}
