using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PutInvoiceRequest(int id, Invoice invoice) : IRequest<PutInvoiceResponse>
    {
        public Invoice invoice { get; } = invoice;
        public int Id { get; set; } = id;
    }
}
