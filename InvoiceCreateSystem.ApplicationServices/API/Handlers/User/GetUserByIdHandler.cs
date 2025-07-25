namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.User;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetUserByIdHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

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
