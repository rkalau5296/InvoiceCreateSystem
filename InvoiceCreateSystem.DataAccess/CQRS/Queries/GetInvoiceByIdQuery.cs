using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetInvoiceByIdQuery : QueryBase<Invoice>
    {
        public int Id { get; set; }
        public GetInvoiceByIdQuery(int id)
        {
            Id = id;
        }
        public override async Task<Invoice> Execute(InvoiceContext context)
        {
            return await context.Invoices.FirstOrDefaultAsync(i => i.Id == Id);
        }
    }
}
