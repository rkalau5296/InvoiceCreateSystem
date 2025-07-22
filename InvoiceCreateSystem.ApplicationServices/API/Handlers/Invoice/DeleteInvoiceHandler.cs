using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    public class DeleteInvoiceHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteInvoiceRequest, DeleteInvoiceResponse>
    {
        private readonly ICommandExecutor commandExecutor = commandExecutor;

        public async Task<DeleteInvoiceResponse> Handle(DeleteInvoiceRequest request, CancellationToken cancellationToken)
        {
            var invoice = new DataAccess.Entities.Invoice { Id = request.Id };

            var command = new DeleteInvoiceCommand { Parametr = invoice };
            await commandExecutor.Execute(command);
            return new DeleteInvoiceResponse();
        }
    }
}
