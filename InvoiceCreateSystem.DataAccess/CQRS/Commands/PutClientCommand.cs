using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PutClientCommand : CommandBase<Client, Client>
{
    public override async Task<Client> Execute(InvoiceContext context)
    {
        var existingClient = await context.Clients.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

        existingClient.Invoices = Parametr.Invoices;
        existingClient.Email = Parametr.Email;
        existingClient.AddressId = Parametr.AddressId;
        existingClient.UserId = Parametr.UserId;

        await context.SaveChangesAsync();
        return existingClient;
    }
}
