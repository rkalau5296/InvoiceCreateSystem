using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetInvoicePositionByIdQuery : QueryBase<InvoicePosition>
    {
        public int Id { get; set; }
        public GetInvoicePositionByIdQuery(int id)
        {
            Id = id;
        }
        public override async Task<InvoicePosition> Execute(InvoiceContext context)
        {
            return await context.InvoicePositions.FirstOrDefaultAsync(i => i.Id == Id);
        }
    }
}
