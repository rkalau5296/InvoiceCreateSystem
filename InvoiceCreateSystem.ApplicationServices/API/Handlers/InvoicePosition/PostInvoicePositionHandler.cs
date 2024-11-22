using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition
{
    using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostInvoicePositionHandler : IRequestHandler<PostInvoicePositionRequest, PostInvoicePositionResponse>
    {

        private readonly IRepository<InvoicePosition> invoicePositionRepository;

        public PostInvoicePositionHandler(IRepository<InvoicePosition> invoicePositionRepository)
        {
            this.invoicePositionRepository = invoicePositionRepository;
        }

        public async Task<PostInvoicePositionResponse> Handle(PostInvoicePositionRequest request, CancellationToken cancellationToken)
        {
            await invoicePositionRepository.Insert(request.invoicePosition);
            return new PostInvoicePositionResponse();
        }
    }
}
