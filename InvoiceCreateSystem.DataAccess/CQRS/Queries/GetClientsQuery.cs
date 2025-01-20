using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetClientsQuery : QueryBase<List<Client>>
    {
        public override async Task<List<Client>> Execute(InvoiceContext context)
        {
            return await context.Clients.ToListAsync();
        }
    }
}
