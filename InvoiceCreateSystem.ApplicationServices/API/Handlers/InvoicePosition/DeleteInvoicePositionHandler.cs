using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition
{
    public class DeleteInvoicePositionHandler : IRequestHandler<DeleteInvoicePositionRequest, DeleteInvoicePositionResponse>
    {
        private readonly IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository;

        public DeleteInvoicePositionHandler(IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository)
        {
            this.invoicePositionRepository = invoicePositionRepository;
        }

        public async Task<DeleteInvoicePositionResponse> Handle(DeleteInvoicePositionRequest request, CancellationToken cancellationToken)
        {
            await invoicePositionRepository.Delete(request.Id);
            return new DeleteInvoicePositionResponse();
        }
    }
}
