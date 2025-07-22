using InvoiceCreateSystem.DataAccess.CQRS.Commands;

namespace InvoiceCreateSystem.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
    }
}
