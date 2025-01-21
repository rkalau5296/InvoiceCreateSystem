using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdRequest, GetInvoiceByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoiceByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
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
}
