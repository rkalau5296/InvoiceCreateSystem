namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

using InvoiceCreateSystem.DataAccess.Entities;
public class PostInvoicePositionCommand : CommandBase<InvoicePosition, InvoicePosition>
{
    public override async Task<InvoicePosition> Execute(InvoiceContext context)
    {
        await context.InvoicePositions.AddAsync(this.Parametr);
        await context.SaveChangesAsync();
        return this.Parametr;
    }
}
