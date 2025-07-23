namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
public class DeleteInvoicePositionCommand : CommandBase<InvoicePosition, InvoicePosition>
{
    public override async Task<InvoicePosition> Execute(InvoiceContext context)
    {
        InvoicePosition existingInvoicePosition = await context.InvoicePositions.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Invoice o Id={Parametr.Id} nie istnieje.");

        context.Remove(existingInvoicePosition);
        await context.SaveChangesAsync();

        return existingInvoicePosition;
    }
}
