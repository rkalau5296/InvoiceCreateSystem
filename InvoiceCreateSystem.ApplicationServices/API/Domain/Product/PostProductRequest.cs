using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Product
{
    using DataAccess.Entities;
    public class PostProductRequest(Product product) : IRequest<PostProductResponse>
    {
        public Product Product { get; } = product;
    }
}