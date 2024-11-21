using InvoiceCreateSystem.ApplicationServices.API.Domain;
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
    public class DeleteInvoicePositionHandler : IRequestHandler<DeleteInvoicePositionRequest, DeleteInvoicePositionResponse>
    {
        private readonly IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository;

        public DeleteInvoicePositionHandler(IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository)
        {
            this.invoicePositionRepository = invoicePositionRepository;
        }

        public async Task<DeleteInvoicePositionResponse> Handle(DeleteInvoicePositionRequest request, CancellationToken cancellationToken)
        {
            await invoicePositionRepository.Delete(request.Id);
            return new DeleteInvoicePositionResponse();
        }
    }
}
