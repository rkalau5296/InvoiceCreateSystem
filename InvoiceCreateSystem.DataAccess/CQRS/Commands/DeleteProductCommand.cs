using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class DeleteProductCommand : CommandBase<Product, Product>
{
    public override async Task<Product> Execute(InvoiceContext context)
    {
        Product product = await context.Products.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Invoice o Id={Parametr.Id} nie istnieje.");

        context.Remove(product);
        await context.SaveChangesAsync();

        return product;
    }
}
