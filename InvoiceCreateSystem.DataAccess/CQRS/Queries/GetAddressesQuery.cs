using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetAddressesQuery : QueryBase<List<Address>>
    {
        public override async Task<List<Address>> Execute(InvoiceContext context)
        {
            return await context.Addresses.ToListAsync();
        }
    }
}
