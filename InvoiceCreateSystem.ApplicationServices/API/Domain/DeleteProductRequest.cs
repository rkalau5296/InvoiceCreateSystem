using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {        
        public int Id { get; }
        public DeleteProductRequest(int id)
        { 
            Id = id; 
        }
    }
}