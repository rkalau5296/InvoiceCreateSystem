using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Queries
{
    public class GetProductByIdQuery : QueryBase<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
        public override async Task<Product> Execute(InvoiceContext context)
        {
            return await context.Products.FirstOrDefaultAsync(product => product.Id == Id);            
        }
    }
}