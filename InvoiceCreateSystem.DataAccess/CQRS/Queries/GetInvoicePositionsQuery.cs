using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetInvoicePositionsQuery : QueryBase<List<InvoicePosition>>
    {       
        public override async Task<List<InvoicePosition>> Execute(InvoiceContext context)
        {
            return await context.InvoicePositions.ToListAsync();
        }
    }
}
