using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class DeleteProductRequest(int id) : IRequest<DeleteProductResponse>
    {
        public int Id { get; } = id;
    }
}