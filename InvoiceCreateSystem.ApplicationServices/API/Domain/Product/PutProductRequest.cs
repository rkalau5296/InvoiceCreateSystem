using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Product
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PutProductRequest(int id, Product product) : IRequest<PutProductResponse>
    {
        public Product Product { get; } = product;
        public int Id { get; set; } = id;
    }
}
