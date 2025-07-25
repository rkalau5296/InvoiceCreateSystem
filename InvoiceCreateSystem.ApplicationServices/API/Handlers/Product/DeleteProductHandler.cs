namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product;

using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;

public class DeleteProductHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;

    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = new DataAccess.Entities.Product { Id = request.Id };

        var command = new DeleteProductCommand { Parametr = product };
        await commandExecutor.Execute(command);
        return new DeleteProductResponse();
    }
}
