using MediatR;
namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Address
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PutAddressRequest(int id, Address address) : IRequest<PutAddressResponse>
    {
        public Address Address { get; } = address;
        public int Id { get; set; } = id;
    }
}