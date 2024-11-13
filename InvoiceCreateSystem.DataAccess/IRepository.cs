using InvoiceCreateSystem.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess
{
    public interface IRepository<T> where T: EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T Entity);
        void Update(T Entity);
        void Delete(int id);
    }
}
