using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostInvoiceRequest(Invoice invoice) : IRequest<PostInvoiceResponse>
    {
        public Invoice invoice { get; } = invoice;
    }
}