using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Address
{
    public class DeleteAddressRequest(int id) : IRequest<DeleteAddressResponse>
    {
        public int Id { get; } = id;
    }
}