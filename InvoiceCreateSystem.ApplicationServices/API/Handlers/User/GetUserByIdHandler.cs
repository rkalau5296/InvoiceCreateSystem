using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        public GetUserByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            GetUserByIdQuery query = new(request.Id);
            DataAccess.Entities.User user = await this.queryExecutor.Execute(query);
            Domain.Models.User mappedUser = mapper.Map<Domain.Models.User>(user);

            GetUserByIdResponse response = new()
            {
                Data = mappedUser,
            };
            return response;
        }
    }
}
