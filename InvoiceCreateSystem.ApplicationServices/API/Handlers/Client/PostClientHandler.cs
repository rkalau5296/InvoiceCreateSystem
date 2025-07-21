namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client;

using AutoMapper;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using InvoiceCreateSystem.DataAccess.Entities;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using MediatR;
public class PostClientHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostClientRequest, PostClientResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<PostClientResponse> Handle(PostClientRequest request, CancellationToken cancellationToken)
    {
        var client = this.mapper.Map<Client>(request);
        var command = new PostClientCommand() { Parametr = client };
        var clientFromDb = await commandExecutor.Execute(command);
        return new PostClientResponse()
        {
            Data = this.mapper.Map<Domain.Models.Client>(clientFromDb)
        };
    }
}
