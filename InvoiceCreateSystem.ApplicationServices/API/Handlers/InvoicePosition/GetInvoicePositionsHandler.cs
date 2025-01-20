using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition
{
    public class GetInvoicePositionsHandler : IRequestHandler<GetInvoicePositionsRequest, GetInvoicePositionsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoicePositionsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInvoicePositionsResponse> Handle(GetInvoicePositionsRequest request, CancellationToken cancellationToken)
        {
            GetInvoicePositionsQuery query = new();
            List<DataAccess.Entities.InvoicePosition> invoicePositions = await this.queryExecutor.Execute(query);
            IEnumerable<Domain.Models.InvoicePosition> mappedInvoicePositions = this.mapper.Map<List<Domain.Models.InvoicePosition>>(invoicePositions);

            GetInvoicePositionsResponse response = new()
            {
                Data = mappedInvoicePositions.ToList(),
            };

            return response;
        }
    }
}
