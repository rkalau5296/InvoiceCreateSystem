using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.User
{
    public class DeleteUserRequest(int id) : IRequest<DeleteUserResponse>
    {
        public int Id { get; } = id;
    }
}