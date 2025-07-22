using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public override async Task<List<Product>> Execute(InvoiceContext context)
        {
            return await context.Products.ToListAsync();
        }
    }
}
