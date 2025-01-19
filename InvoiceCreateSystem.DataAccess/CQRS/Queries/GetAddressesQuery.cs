using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetAddressesQuery : QueryBase<List<Address>>
    {
        public override async Task<List<Address>> Execute(InvoiceContext context)
        {
            return await context.Addresses.ToListAsync();
        }
    }
}
