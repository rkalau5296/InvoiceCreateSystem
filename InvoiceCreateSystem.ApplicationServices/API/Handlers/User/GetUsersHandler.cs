namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetUsersHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetUsersRequest, GetUsersResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

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
