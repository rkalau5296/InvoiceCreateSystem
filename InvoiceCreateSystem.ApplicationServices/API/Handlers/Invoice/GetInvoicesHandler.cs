using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetInvoicesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            GetInvoicesQuery query = new();
            List<DataAccess.Entities.Invoice> invoice = await this.queryExecutor.Execute(query);
            IEnumerable<Domain.Models.Invoice> mappedInvoice = this.mapper.Map<List<Domain.Models.Invoice>>(invoice);

            GetInvoicesResponse response = new()
            {
                Data = mappedInvoice.ToList(),
            };

            return response;
        }
    }
}
