namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address;

using MediatR;
using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;    
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;    
public class PostAddressHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostAddressRequest, PostAddressResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<PostAddressResponse> Handle(PostAddressRequest request, CancellationToken cancellationToken)
    {            
        var command = new PostAddressCommand() { Parametr = request.Address };
        var addressFromDb = await commandExecutor.Execute(command);
        return new PostAddressResponse()
        {
            Data = this.mapper.Map<Domain.Models.Address>(addressFromDb)
        };
    }
}
