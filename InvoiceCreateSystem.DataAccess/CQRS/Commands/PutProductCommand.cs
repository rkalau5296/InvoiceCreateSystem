
using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PutProductCommand : CommandBase<Product, Product>
{
    public override async Task<Product> Execute(InvoiceContext context)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

        existingProduct.Name = Parametr.Name;

        await context.SaveChangesAsync();
        return existingProduct;
    }
}
