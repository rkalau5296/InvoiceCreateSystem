using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.User
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostUserRequest(User user) : IRequest<PostUserResponse>
    {
        public User user { get; } = user;
    }
}