using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.User
{
    public class GetUserByIdRequest(int id) : IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
