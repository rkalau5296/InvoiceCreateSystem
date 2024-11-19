using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class PutProductRequest(int id, Product product) : IRequest<PutProductResponse>
    {
        public Product Product { get; } = product;
        public int Id { get; set; } = id;
    }
}
