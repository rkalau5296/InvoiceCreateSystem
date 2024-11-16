using InvoiceCreateSystem.DataAccess.Entities;

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
