using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostMethodOfPaymentHandler : IRequestHandler<PostMethodOfPaymentRequest, PostMethodOfPaymentResponse>
    {

        private readonly IRepository<MethodOfPayment> methodOfPaymentRepository;

        public PostMethodOfPaymentHandler(IRepository<MethodOfPayment> methodOfPaymentRepository)
        {
            this.methodOfPaymentRepository = methodOfPaymentRepository;
        }

        public async Task<PostMethodOfPaymentResponse> Handle(PostMethodOfPaymentRequest request, CancellationToken cancellationToken)
        {
            await methodOfPaymentRepository.Insert(request.MethodOfPayment);
            return new PostMethodOfPaymentResponse();
        }
    }
}
