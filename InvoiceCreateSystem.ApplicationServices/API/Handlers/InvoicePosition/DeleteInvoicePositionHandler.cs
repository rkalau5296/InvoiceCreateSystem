namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition;

using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class DeleteInvoicePositionHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteInvoicePositionRequest, DeleteInvoicePositionResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;        

    public async Task<DeleteInvoicePositionResponse> Handle(DeleteInvoicePositionRequest request, CancellationToken cancellationToken)
    {
        var invoicePosition = new DataAccess.Entities.InvoicePosition { Id = request.Id };

        var command = new DeleteInvoicePositionCommand { Parametr = invoicePosition };
        await commandExecutor.Execute(command);
        return new DeleteInvoicePositionResponse();
    }
}
