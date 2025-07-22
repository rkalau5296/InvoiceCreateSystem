using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetMethodOfPaymentsQuery : QueryBase<List<MethodOfPayment>>
    {
        public override async Task<List<MethodOfPayment>> Execute(InvoiceContext context)
        {
            return await context.MethodOfPayments.ToListAsync();
        }
    }
}
