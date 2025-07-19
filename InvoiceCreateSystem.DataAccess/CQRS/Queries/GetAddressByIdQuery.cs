namespace InvoiceCreateSystem.DataAccess.CQRS.Queries;

using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
public class GetAddressByIdQuery(int id) : QueryBase<Address>
{
    public int Id { get; set; } = id;

    public override async Task<Address> Execute(InvoiceContext context)
    {
        return await context.Addresses.FirstOrDefaultAsync(a => a.Id == Id);
    }
}
