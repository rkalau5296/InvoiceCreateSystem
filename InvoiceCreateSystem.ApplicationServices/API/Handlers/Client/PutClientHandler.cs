﻿namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PutClientHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PutClientRequest, PutClientResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;    

    public async Task<PutClientResponse> Handle(PutClientRequest request, CancellationToken cancellationToken)
    {
        var client = mapper.Map<DataAccess.Entities.Client>(request.Client);

        client.Id = request.Id;

        var command = new PutClientCommand { Parametr = client };
        var updatedClient = await commandExecutor.Execute(command);

        var domainClient = mapper.Map<Domain.Models.Client>(updatedClient);

        return new PutClientResponse { Data = domainClient };
    }
}
