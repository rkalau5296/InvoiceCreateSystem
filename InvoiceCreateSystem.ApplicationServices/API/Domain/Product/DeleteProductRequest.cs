using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Product
{
    public class DeleteProductRequest(int id) : IRequest<DeleteProductResponse>
    {
        public int Id { get; } = id;
    }
}