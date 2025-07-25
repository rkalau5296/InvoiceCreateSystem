using InvoiceCreateSystem.DataAccess.Entities;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PostMethodOfPaymentCommand : CommandBase<MethodOfPayment, MethodOfPayment>
{
    public override async Task<MethodOfPayment> Execute(InvoiceContext context)
    {
        await context.MethodOfPayments.AddAsync(this.Parametr);
        await context.SaveChangesAsync();
        return this.Parametr;
    }
}
