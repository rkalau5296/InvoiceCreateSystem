using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetProductQuery : QueryBase<Product>
    {
        public int Id { get; set; }
        public override async Task<Product> Execute(InvoiceContext context)
        {
            return await context.Products.FirstOrDefaultAsync(book => book.Id == this.Id);
        }
    }
}
