using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class PostUserHandler : IRequestHandler<PostUserRequest, PostUserResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> userRepository;

        public PostUserHandler(IRepository<DataAccess.Entities.User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
        }

        public async Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
        {
            await userRepository.Insert(request.user);
            return new PostUserResponse();
        }
    }
}
