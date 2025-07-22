namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
public class DeleteInvoiceCommand : CommandBase<Invoice, Invoice>
{
    public override async Task<Invoice> Execute(InvoiceContext context)
    {
        Invoice existingInvoice = await context.Invoices.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Invoice o Id={Parametr.Id} nie istnieje.");

        context.Remove(existingInvoice);
        await context.SaveChangesAsync();

        return existingInvoice;
    }
}
