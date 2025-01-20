using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public override async Task<List<User>> Execute(InvoiceContext context)
        {
            return await context.Users.ToListAsync();
        }
    }
}
