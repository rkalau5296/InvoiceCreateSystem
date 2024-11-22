using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostInvoiceHandler : IRequestHandler<PostInvoiceRequest, PostInvoiceResponse>
    {

        private readonly IRepository<Invoice> invoiceRepository;

        public PostInvoiceHandler(IRepository<Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<PostInvoiceResponse> Handle(PostInvoiceRequest request, CancellationToken cancellationToken)
        {
            await invoiceRepository.Insert(request.invoice);
            return new PostInvoiceResponse();
        }
    }
}
