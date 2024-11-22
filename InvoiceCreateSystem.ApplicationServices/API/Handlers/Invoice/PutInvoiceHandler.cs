using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    public class PutInvoiceHandler : IRequestHandler<PutInvoiceRequest, PutInvoiceResponse>
    {
        private readonly IRepository<DataAccess.Entities.Invoice> invoiceRepository;

        public PutInvoiceHandler(IRepository<DataAccess.Entities.Invoice> invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<PutInvoiceResponse> Handle(PutInvoiceRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Invoice invoice = await this.invoiceRepository.GetById(request.Id);

            invoice.Id = request.invoice.Id;
            invoice.Title = request.invoice.Title;
            invoice.Value = request.invoice.Value;
            invoice.MethodOfPaymentId = request.invoice.MethodOfPaymentId;
            invoice.PaymentDate = request.invoice.PaymentDate;
            invoice.CreatedDate = request.invoice.CreatedDate;
            invoice.Comments = request.invoice.Comments;
            invoice.ClientId = request.invoice.ClientId;
            invoice.UserId = request.invoice.UserId;

            await invoiceRepository.Update(invoice);
            return new PutInvoiceResponse();
        }
    }
}
