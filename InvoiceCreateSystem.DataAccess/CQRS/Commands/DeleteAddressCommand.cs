using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;
public class DeleteAddressCommand : CommandBase<Address, Address>
{
    public override async Task<Address> Execute(InvoiceContext context)
    {
        Address existingAddress = await context.Addresses.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

        context.Remove(existingAddress);
        await context.SaveChangesAsync();

        return existingAddress;
    }
}
