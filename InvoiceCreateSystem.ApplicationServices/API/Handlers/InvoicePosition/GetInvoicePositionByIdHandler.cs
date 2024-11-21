using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class GetInvoicePositionByIdHandler : IRequestHandler<GetInvoicePositionByIdRequest, GetInvoicePositionByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository;
        private readonly IMapper mapper;

        public GetInvoicePositionByIdHandler(IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository, IMapper mapper)
        {
            this.invoicePositionRepository = invoicePositionRepository;
            this.mapper = mapper;
        }
        public async Task<GetInvoicePositionByIdResponse> Handle(GetInvoicePositionByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.InvoicePosition client = await this.invoicePositionRepository.GetById(request.Id);
            Domain.Models.InvoicePosition mappedClient = mapper.Map<Domain.Models.InvoicePosition>(client);

            GetInvoicePositionByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}
