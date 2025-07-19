using InvoiceCreateSystem.DataAccess.Entities;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public class PostClientCommand : CommandBase<Client, Client>
    {
        public override async Task<Client> Execute(InvoiceContext context)
        {
            await context.Clients.AddAsync(this.Parametr);
            await context.SaveChangesAsync();
            return this.Parametr;
        }
    }
}
