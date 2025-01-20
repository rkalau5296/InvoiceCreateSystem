using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            GetUsersQuery query = new();
            List<DataAccess.Entities.User> users = await queryExecutor.Execute(query);
            IEnumerable<Domain.Models.User> mappedUsers = mapper.Map<List<Domain.Models.User>>(users);

            GetUsersResponse response = new()
            {
                Data = mappedUsers.ToList(),
            };

            return response;
        }
    }
}
