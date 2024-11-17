using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class PostProductRequest : IRequest<PostProductResponse>
    {
        public Product Product { get; }
        public PostProductRequest(Product product) 
        {
            this.Product = product;
        }
    }
}
