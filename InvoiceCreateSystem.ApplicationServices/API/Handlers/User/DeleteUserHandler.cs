namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User;

using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class DeleteUserHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;   

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = new DataAccess.Entities.User { Id = request.Id };

        var command = new DeleteUserCommand { Parametr = user };
        await commandExecutor.Execute(command);
        return new DeleteUserResponse();
    }
}
