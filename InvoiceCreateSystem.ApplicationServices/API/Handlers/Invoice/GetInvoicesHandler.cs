using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesRequest, GetInvoicesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Invoice> invoiceRepository;
        private readonly IMapper mapper;

        public GetInvoicesHandler(IRepository<DataAccess.Entities.Invoice> invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }
        public async Task<GetInvoicesResponse> Handle(GetInvoicesRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.Invoice> invoice = await this.invoiceRepository.GetAll();
            IEnumerable<Domain.Models.Invoice> mappedInvoice = this.mapper.Map<List<Domain.Models.Invoice>>(invoice);

            GetInvoicesResponse response = new()
            {
                Data = mappedInvoice.ToList(),
            };

            return response;
        }
    }
}
