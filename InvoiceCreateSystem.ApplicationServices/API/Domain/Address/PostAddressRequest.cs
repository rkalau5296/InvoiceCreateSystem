using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Address
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostAddressRequest(Address address) : IRequest<PostAddressResponse>
    {
        public Address Address { get; } = address;
    }
}