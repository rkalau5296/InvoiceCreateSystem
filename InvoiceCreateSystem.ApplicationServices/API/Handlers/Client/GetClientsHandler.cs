namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetClientsHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetClientsRequest, GetClientsResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
    {
        GetClientsQuery query = new();
        List<DataAccess.Entities.Client> clients = await this.queryExecutor.Execute(query);
        IEnumerable<Domain.Models.Client> mappedClient = this.mapper.Map<List<Domain.Models.Client>>(clients);

        GetClientsResponse response = new()
        {
            Data = mappedClient.ToList(),
        };

        return response;
    }
}
