using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PutInvoiceCommand : CommandBase<Invoice, Invoice>
{
    public override async Task<Invoice> Execute(InvoiceContext context)
    {
        var existingInvoice = await context.Invoices.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

        existingInvoice.Value = Parametr.Value;
        existingInvoice.Title = Parametr.Title;
        existingInvoice.PaymentDate = Parametr.PaymentDate;
        existingInvoice.CreatedDate = Parametr.CreatedDate;
        existingInvoice.Comments = Parametr.Comments;

        await context.SaveChangesAsync();
        return existingInvoice;
    }
}
