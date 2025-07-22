using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public class DeleteClientCommand : CommandBase<Client, Client>
    {
        public override async Task<Client> Execute(InvoiceContext context)
        {
            Client existingClient = await context.Clients.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Client o Id={Parametr.Id} nie istnieje.");

            context.Remove(existingClient);
            await context.SaveChangesAsync();

            return existingClient;
        }
    }
}
