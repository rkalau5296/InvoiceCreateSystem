using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
