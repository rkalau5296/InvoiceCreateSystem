using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PutUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(InvoiceContext context)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Adres o Id={Parametr.Id} nie istnieje.");

        existingUser.Name = Parametr.Name;
        existingUser.Email = Parametr.Name;        
        existingUser.Password = Parametr.Password;

        await context.SaveChangesAsync();
        return existingUser;
    }
}
