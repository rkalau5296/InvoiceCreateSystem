using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdRequest, GetInvoiceByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.Invoice> invoiceRepository;
        private readonly IMapper mapper;

        public GetInvoiceByIdHandler(IRepository<DataAccess.Entities.Invoice> invoiceRepository, IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }
        public async Task<GetInvoiceByIdResponse> Handle(GetInvoiceByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Invoice client = await this.invoiceRepository.GetById(request.Id);
            Domain.Models.Invoice mappedClient = mapper.Map<Domain.Models.Invoice>(client);

            GetInvoiceByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}
