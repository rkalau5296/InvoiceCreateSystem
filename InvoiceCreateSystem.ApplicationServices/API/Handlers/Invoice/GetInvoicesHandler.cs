namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
    {
        GetInvoicesQuery query = new();
        List<DataAccess.Entities.Invoice> invoice = await this.queryExecutor.Execute(query);
        IEnumerable<Domain.Models.Invoice> mappedInvoice = this.mapper.Map<List<Domain.Models.Invoice>>(invoice);

        GetInvoicesResponse response = new()
        {
            Data = [.. mappedInvoice],
        };

        return response;
    }
}
