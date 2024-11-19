using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Client
{
    using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
    public class PostClientRequest(Client client) : IRequest<PostClientResponse>
    {
        public Client Client { get; } = client;
    }
}