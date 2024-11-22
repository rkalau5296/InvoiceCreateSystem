using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
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
            List<DataAccess.Entities.Invoice> clients = await this.invoiceRepository.GetAll();
            IEnumerable<Domain.Models.Invoice> mappedClient = this.mapper.Map<List<Domain.Models.Invoice>>(clients);

            GetInvoicesResponse response = new()
            {
                Data = mappedClient.ToList(),
            };

            return response;
        }
    }
}
