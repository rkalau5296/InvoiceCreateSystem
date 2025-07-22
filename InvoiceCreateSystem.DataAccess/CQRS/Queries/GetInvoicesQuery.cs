using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetInvoicesQuery : QueryBase<List<Invoice>>
    {
        public override async Task<List<Invoice>> Execute(InvoiceContext context)
        {
            return await context.Invoices.ToListAsync();
        }
    }
}
