using InvoiceCreateSystem.DataAccess.CQRS.Queries;

namespace InvoiceCreateSystem.DataAccess.CQRS
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
