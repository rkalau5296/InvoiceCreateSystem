using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
