using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Client
{
    public class GetClientByIdRequest(int id) : IRequest<GetClientByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
