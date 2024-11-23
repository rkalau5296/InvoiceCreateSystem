using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> userRepository;

        public DeleteUserHandler(IRepository<DataAccess.Entities.User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            await userRepository.Delete(request.Id);
            return new DeleteUserResponse();
        }
    }
}
