namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PostProductHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostProductRequest, PostProductResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;      

    public async Task<PostProductResponse> Handle(PostProductRequest request, CancellationToken cancellationToken)
    {
        var product = this.mapper.Map<DataAccess.Entities.Product>(request);
        var command = new PostProductCommand() { Parametr = product };
        var productFromDb = await commandExecutor.Execute(command);
        return new PostProductResponse()
        {
            Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
        };
    }
}
