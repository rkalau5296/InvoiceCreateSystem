using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    public class DeleteMethodOfPaymentHandler : IRequestHandler<DeleteMethodOfPaymentRequest, DeleteMethodOfPaymentResponse>
    {
        private readonly IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository;

        public DeleteMethodOfPaymentHandler(IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository)
        {
            this.methodOfPaymentRepository = methodOfPaymentRepository;
        }

        public async Task<DeleteMethodOfPaymentResponse> Handle(DeleteMethodOfPaymentRequest request, CancellationToken cancellationToken)
        {
            await methodOfPaymentRepository.Delete(request.Id);
            return new DeleteMethodOfPaymentResponse();
        }
    }
}
