namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class PutMethodOfPaymentCommand : CommandBase<MethodOfPayment, MethodOfPayment>
{
    public override async Task<MethodOfPayment> Execute(InvoiceContext context)
    {
        var existingMethodOfPayment = await context.MethodOfPayments.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

        existingMethodOfPayment.Name = Parametr.Name;     

        await context.SaveChangesAsync();
        return existingMethodOfPayment;
    }
}
