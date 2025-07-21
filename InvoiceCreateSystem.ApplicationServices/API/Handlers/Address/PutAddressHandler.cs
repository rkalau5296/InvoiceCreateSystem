namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class PutAddressHandler(ICommandExecutor commandExecutor,  IMapper mapper) : IRequestHandler<PutAddressRequest, PutAddressResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<PutAddressResponse> Handle(PutAddressRequest request, CancellationToken cancellationToken)
    {
        var address = mapper.Map<DataAccess.Entities.Address>(request.Address);

        address.Id= request.Id;

        var command = new PutAddressCommand { Parametr = address };
        var updatedAddress = await commandExecutor.Execute(command);

        var domainAddress = mapper.Map<Domain.Models.Address>(updatedAddress);

        return new PutAddressResponse { Data = domainAddress };
    }
}
