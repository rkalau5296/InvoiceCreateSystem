using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.User
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PutUserRequest(int id, User user) : IRequest<PutUserResponse>
    {
        public User User { get; } = user;
        public int Id { get; set; } = id;
    }
}
