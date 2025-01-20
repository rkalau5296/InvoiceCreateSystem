using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
