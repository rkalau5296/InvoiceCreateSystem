using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice
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
            DataAccess.Entities.Invoice invoice = await this.invoiceRepository.GetById(request.Id);
            Domain.Models.Invoice mappedInvoice = mapper.Map<Domain.Models.Invoice>(invoice);

            GetInvoiceByIdResponse response = new()
            {
                Data = mappedInvoice,
            };

            return response;
        }
    }
}
