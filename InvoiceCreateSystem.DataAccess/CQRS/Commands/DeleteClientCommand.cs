using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public class DeleteClientCommand : CommandBase<Client, Client>
    {
        public override async Task<Client> Execute(InvoiceContext context)
        {
            Client existingClient = await context.Clients.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

            context.Remove(existingClient);
            await context.SaveChangesAsync();

            return existingClient;
        }
    }
}
