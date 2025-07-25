using InvoiceCreateSystem.DataAccess.Entities;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PostProductCommand : CommandBase<Product, Product>
{
    public override async Task<Product> Execute(InvoiceContext context)
    {
        await context.Products.AddAsync(this.Parametr);
        await context.SaveChangesAsync();
        return this.Parametr;
    }
}
