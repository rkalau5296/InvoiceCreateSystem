using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class PutProductRequest : IRequest<PutProductResponse>
    {
        public Product Product { get; }
        public int Id { get; set; }
        public PutProductRequest(int id, Product product)
        {
            this.Id = id;
            this.Product = product;
        }
    }
}
