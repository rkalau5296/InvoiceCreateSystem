using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostInvoicePositionRequest(InvoicePosition invoicePosition) : IRequest<PostInvoicePositionResponse>
    {
        public InvoicePosition invoicePosition { get; } = invoicePosition;
    }
}