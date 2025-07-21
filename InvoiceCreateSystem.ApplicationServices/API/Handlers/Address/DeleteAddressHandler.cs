namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;

public class DeleteAddressHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteAddressRequest, DeleteAddressResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;     

    public async Task<DeleteAddressResponse> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        var address = new DataAccess.Entities.Address { Id = request.Id};

        var command = new DeleteAddressCommand { Parametr = address };
        await commandExecutor.Execute(command);
        return new DeleteAddressResponse();
    }
}
