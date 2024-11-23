using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class PutUserHandler : IRequestHandler<PutUserRequest, PutUserResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> userRepository;

        public PutUserHandler(IRepository<DataAccess.Entities.User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<PutUserResponse> Handle(PutUserRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.User user = await userRepository.GetById(request.Id);
            user.Name = request.user.Name;
            user.Email = request.user.Email;
            user.Password = request.user.Email;

            await userRepository.Update(user);
            return new PutUserResponse();
        }
    }
}
