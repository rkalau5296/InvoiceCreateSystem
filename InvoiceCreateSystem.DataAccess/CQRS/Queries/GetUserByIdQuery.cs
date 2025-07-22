using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetUserByIdQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public override async Task<User> Execute(InvoiceContext context)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }
    }
}
