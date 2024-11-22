using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    public class PutMethodOfPaymentHandler : IRequestHandler<PutMethodOfPaymentRequest, PutMethodOfPaymentResponse>
    {
        private readonly IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository;

        public PutMethodOfPaymentHandler(IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository)
        {
            this.methodOfPaymentRepository = methodOfPaymentRepository;
        }

        public async Task<PutMethodOfPaymentResponse> Handle(PutMethodOfPaymentRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.MethodOfPayment methodOfPayment = await this.methodOfPaymentRepository.GetById(request.Id);

            methodOfPayment.Name = request.methodOfPayments.Name;
            methodOfPayment.UserId = request.methodOfPayments.UserId;                       

            await methodOfPaymentRepository.Update(methodOfPayment);
            return new PutMethodOfPaymentResponse();
        }
    }
}
