namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetInvoicePositionsHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetInvoicePositionsRequest, GetInvoicePositionsResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetInvoicePositionsResponse> Handle(GetInvoicePositionsRequest request, CancellationToken cancellationToken)
    {
        GetInvoicePositionsQuery query = new();
        List<DataAccess.Entities.InvoicePosition> invoicePositions = await this.queryExecutor.Execute(query);
        IEnumerable<Domain.Models.InvoicePosition> mappedInvoicePositions = this.mapper.Map<List<Domain.Models.InvoicePosition>>(invoicePositions);

        GetInvoicePositionsResponse response = new()
        {
            Data = [.. mappedInvoicePositions],
        };

        return response;
    }
}
