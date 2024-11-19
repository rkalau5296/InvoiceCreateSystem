using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class PostProductRequest(Product product) : IRequest<PostProductResponse>
    {
        public Product Product { get; } = product;
    }
}