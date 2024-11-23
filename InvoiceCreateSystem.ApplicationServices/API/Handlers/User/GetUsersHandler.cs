using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> userRepository;
        private readonly IMapper mapper;

        public GetUsersHandler(IRepository<DataAccess.Entities.User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.User> users = await userRepository.GetAll();
            IEnumerable<Domain.Models.User> mappedUsers = mapper.Map<List<Domain.Models.User>>(users);

            GetUsersResponse response = new()
            {
                Data = mappedUsers.ToList(),
            };

            return response;
        }
    }
}
