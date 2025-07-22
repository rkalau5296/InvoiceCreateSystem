using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetClientByIdQuery : QueryBase<Client>
    {
        public int Id { get; set; }
        public GetClientByIdQuery(int id)
        { 
            Id = id;
        }
        public override async Task<Client> Execute(InvoiceContext context)
        {
            return await context.Clients.FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
