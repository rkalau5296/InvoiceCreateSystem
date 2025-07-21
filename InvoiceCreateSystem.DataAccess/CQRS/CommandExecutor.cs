namespace InvoiceCreateSystem.DataAccess.CQRS;

using InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class CommandExecutor(InvoiceContext context) : ICommandExecutor
{
    private readonly InvoiceContext context = context;

    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(context);
    }
}
