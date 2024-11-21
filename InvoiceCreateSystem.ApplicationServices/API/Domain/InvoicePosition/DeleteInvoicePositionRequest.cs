using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition
{
    public class DeleteInvoicePositionRequest(int id) : IRequest<DeleteInvoicePositionResponse>
    {
        public int Id { get; } = id;
    }
}