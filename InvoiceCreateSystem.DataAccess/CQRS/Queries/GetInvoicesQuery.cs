using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
