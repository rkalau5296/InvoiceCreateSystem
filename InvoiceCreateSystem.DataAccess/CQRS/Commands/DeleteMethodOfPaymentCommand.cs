using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;
public class DeleteMethodOfPaymentCommand : CommandBase<MethodOfPayment, MethodOfPayment>
{
    public override async Task<MethodOfPayment> Execute(InvoiceContext context)
    {
        MethodOfPayment existingMethodOfPayment = await context.MethodOfPayments.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Invoice o Id={Parametr.Id} nie istnieje.");

        context.Remove(existingMethodOfPayment);
        await context.SaveChangesAsync();

        return existingMethodOfPayment;
    }
}
