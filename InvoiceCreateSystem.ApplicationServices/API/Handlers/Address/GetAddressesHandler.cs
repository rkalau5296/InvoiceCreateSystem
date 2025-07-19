namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetAddressesHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetAddressesRequest, GetAddressesResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetAddressesResponse> Handle(GetAddressesRequest request, CancellationToken cancellationToken)
    {
        GetAddressesQuery query = new();
        List<DataAccess.Entities.Address> addresses = await this.queryExecutor.Execute(query);
        IEnumerable<Domain.Models.Address> mappedClient = this.mapper.Map<List<Domain.Models.Address>>(addresses);

        GetAddressesResponse response = new()
        {
            Data = mappedClient.ToList(),
        };

        return response;
    }
}
