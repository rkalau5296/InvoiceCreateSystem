using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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
