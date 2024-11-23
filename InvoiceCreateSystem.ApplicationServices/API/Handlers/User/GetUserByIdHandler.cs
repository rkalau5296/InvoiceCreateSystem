using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.User> userRepository;
        private readonly IMapper mapper;
        public GetUserByIdHandler(IRepository<DataAccess.Entities.User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.User user = await userRepository.GetById(request.Id);

            Domain.Models.User mappedUser = mapper.Map<Domain.Models.User>(user);

            GetUserByIdResponse response = new()
            {
                Data = mappedUser,
            };
            return response;
        }
    }
}
