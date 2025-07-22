namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

using InvoiceCreateSystem.DataAccess.Entities;
public class PostInvoiceCommand : CommandBase<Invoice, Invoice>
{
    public override async Task<Invoice> Execute(InvoiceContext context)
    {
        await context.Invoices.AddAsync(this.Parametr);
        await context.SaveChangesAsync();
        return this.Parametr;
    }
}
