using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Client
{
    public class DeleteClientRequest(int id) : IRequest<DeleteClientResponse>
    {
        public int Id { get; } = id;
    }
}