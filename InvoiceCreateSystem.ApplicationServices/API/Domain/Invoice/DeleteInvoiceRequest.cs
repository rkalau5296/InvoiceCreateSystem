using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice
{
    public class DeleteInvoiceRequest(int id) : IRequest<DeleteInvoiceResponse>
    {
        public int Id { get; } = id;
    }
}