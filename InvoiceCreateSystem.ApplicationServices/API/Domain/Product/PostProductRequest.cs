using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Product
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostProductRequest(Product product) : IRequest<PostProductResponse>
    {
        public Product Product { get; } = product;
    }
}