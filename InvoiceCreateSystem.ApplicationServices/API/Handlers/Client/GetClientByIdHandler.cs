namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetClientByIdHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        GetClientByIdQuery query = new(request.Id);
        DataAccess.Entities.Client client = await this.queryExecutor.Execute(query);
        Domain.Models.Client mappedClient = mapper.Map<Domain.Models.Client>(client);

        GetClientByIdResponse response = new()
        {
            Data = mappedClient,
        };

        return response;
    }
}
