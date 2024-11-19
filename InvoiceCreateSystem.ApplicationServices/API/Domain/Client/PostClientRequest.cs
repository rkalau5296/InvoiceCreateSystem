using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Client
{
    
    public class PostClientRequest(DataAccess.Entities.Client client) : IRequest<PostClientResponse>
    {
        public DataAccess.Entities.Client Client { get; } = client;
    }
}