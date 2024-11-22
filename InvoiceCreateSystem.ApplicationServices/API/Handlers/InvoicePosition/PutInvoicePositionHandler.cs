using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition
{
    public class PutInvoicePositionHandler : IRequestHandler<PutInvoicePositionRequest, PutInvoicePositionResponse>
    {
        private readonly IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository;

        public PutInvoicePositionHandler(IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository)
        {
            this.invoicePositionRepository = invoicePositionRepository;
        }

        public async Task<PutInvoicePositionResponse> Handle(PutInvoicePositionRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.InvoicePosition invoicePosition = await this.invoicePositionRepository.GetById(request.Id);

            invoicePosition.Lp = request.invoicePosition.Lp;
            invoicePosition.Value = request.invoicePosition.Value;
            invoicePosition.Quantity = request.invoicePosition.Quantity;           

            await invoicePositionRepository.Update(invoicePosition);
            return new PutInvoicePositionResponse();
        }
    }
}
