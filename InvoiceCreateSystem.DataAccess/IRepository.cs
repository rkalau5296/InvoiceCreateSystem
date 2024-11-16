using InvoiceCreateSystem.DataAccess.Entities;

namespace InvoiceCreateSystem.DataAccess
{
    public interface IRepository<T> where T: EntityBase
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T Entity);
        Task Update(T Entity);
        Task Delete(int id);
    }
}
