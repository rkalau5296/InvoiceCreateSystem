using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceRequest, DeleteInvoiceResponse>
    {
        private readonly IRepository<DataAccess.Entities.Invoice> invoiceRepository;

        public DeleteInvoiceHandler(IRepository<DataAccess.Entities.Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<DeleteInvoiceResponse> Handle(DeleteInvoiceRequest request, CancellationToken cancellationToken)
        {
            await invoiceRepository.Delete(request.Id);
            return new DeleteInvoiceResponse();
        }
    }
}
