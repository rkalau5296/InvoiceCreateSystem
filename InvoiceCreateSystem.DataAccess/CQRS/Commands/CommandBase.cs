namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParametr, TResult>
    {
        public TParametr Parametr { get; set; }

        public abstract Task<TResult> Execute(InvoiceContext context);
    }
}
