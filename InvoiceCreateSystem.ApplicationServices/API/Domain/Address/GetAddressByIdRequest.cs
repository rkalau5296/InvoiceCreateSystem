using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Address
{
    public class GetAddressByIdRequest(int id) : IRequest<GetAddressByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
