namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetInvoiceByIdHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetInvoiceByIdRequest, GetInvoiceByIdResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetInvoiceByIdResponse> Handle(GetInvoiceByIdRequest request, CancellationToken cancellationToken)
    {
        GetInvoiceByIdQuery query = new(request.Id);
        DataAccess.Entities.Invoice invoice = await this.queryExecutor.Execute(query);
        Domain.Models.Invoice mappedInvoice = mapper.Map<Domain.Models.Invoice>(invoice);

        GetInvoiceByIdResponse response = new()
        {
            Data = mappedInvoice,
        };

        return response;
    }
}
