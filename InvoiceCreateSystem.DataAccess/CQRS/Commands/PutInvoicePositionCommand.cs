using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands
{
    public class PutInvoicePositionCommand : CommandBase<InvoicePosition, InvoicePosition>
    {
        public override async Task<InvoicePosition> Execute(InvoiceContext context)
        {
            var existingInvoicePosition = await context.InvoicePositions.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

            existingInvoicePosition.Lp = Parametr.Lp;
            existingInvoicePosition.Value = Parametr.Value;
            existingInvoicePosition.Quantity = Parametr.Quantity;
            existingInvoicePosition.Invoice = Parametr.Invoice;
            existingInvoicePosition.Product = Parametr.Product;

            await context.SaveChangesAsync();
            return existingInvoicePosition;
        }
    }
}
