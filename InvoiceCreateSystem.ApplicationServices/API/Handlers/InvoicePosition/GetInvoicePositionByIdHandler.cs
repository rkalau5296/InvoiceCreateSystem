using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition
{
    public class GetInvoicePositionByIdHandler : IRequestHandler<GetInvoicePositionByIdRequest, GetInvoicePositionByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoicePositionByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
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
}
