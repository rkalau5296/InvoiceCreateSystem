using InvoiceCreateSystem.DataAccess.Entities;

namespace InvoiceCreateSystem.DataAccess.CQRS.Commands;

public class PostUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(InvoiceContext context)
    {
        await context.Users.AddAsync(this.Parametr);
        await context.SaveChangesAsync();
        return this.Parametr;
    }
}
