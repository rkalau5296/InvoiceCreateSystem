using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class DeleteUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(InvoiceContext context)
    {
        User user = await context.Users.FirstOrDefaultAsync(a => a.Id == Parametr.Id) ?? throw new InvalidOperationException($"Invoice o Id={Parametr.Id} nie istnieje.");

        context.Remove(user);
        await context.SaveChangesAsync();

        return user;
    }
}
