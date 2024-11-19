using MediatR;
namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Client
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PutClientRequest(int id, Client client) : IRequest<PutClientResponse>
    {
        public Client Client { get; } = client;
        public int Id { get; set; } = id;
    }
}