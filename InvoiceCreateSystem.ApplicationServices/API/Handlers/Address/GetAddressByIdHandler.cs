namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetAddressByIdHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetAddressByIdRequest, GetAddressByIdResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetAddressByIdResponse> Handle(GetAddressByIdRequest request, CancellationToken cancellationToken)
    {
        GetAddressByIdQuery query = new(request.Id);
        DataAccess.Entities.Address address = await this.queryExecutor.Execute(query);
        Domain.Models.Address mappedClient = mapper.Map<Domain.Models.Address>(address);

        GetAddressByIdResponse response = new()
        {
            Data = mappedClient,
        };

        return response;
    }
}
