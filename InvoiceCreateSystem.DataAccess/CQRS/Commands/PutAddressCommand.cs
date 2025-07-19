namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

public class PutAddressCommand : CommandBase<Address, Address>
{
    public override async Task<Address> Execute(InvoiceContext context)
    {
        var existingAddress = await context.Addresses.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");
                
        existingAddress.Street = Parametr.Street;
        existingAddress.Number = Parametr.Number;
        existingAddress.City = Parametr.City;
        existingAddress.PostalCode = Parametr.PostalCode;

        await context.SaveChangesAsync();
        return existingAddress;
    }
}
