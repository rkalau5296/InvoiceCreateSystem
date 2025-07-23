namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetInvoicePositionByIdHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetInvoicePositionByIdRequest, GetInvoicePositionByIdResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetInvoicePositionByIdResponse> Handle(GetInvoicePositionByIdRequest request, CancellationToken cancellationToken)
    {
        GetInvoicePositionByIdQuery query = new(request.Id);
        DataAccess.Entities.InvoicePosition invoicePosition = await this.queryExecutor.Execute(query);
        Domain.Models.InvoicePosition mappediInvoicePosition = mapper.Map<Domain.Models.InvoicePosition>(invoicePosition);

        GetInvoicePositionByIdResponse response = new()
        {
            Data = mappediInvoicePosition,
        };

        return response;
    }
}
