using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetMethodOfPaymentByIdQuery : QueryBase<MethodOfPayment>
    {
        public int Id { get; set; }
        public GetMethodOfPaymentByIdQuery(int id)
        {
            Id = id;
        }

        public override async Task<MethodOfPayment> Execute(InvoiceContext context)
        {
            return await context.MethodOfPayments.FirstOrDefaultAsync(mp => mp.Id == Id);
        }
    }
}
