using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment
{    
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostMethodOfPaymentRequest(MethodOfPayment MethodOfPayment) : IRequest<PostMethodOfPaymentResponse>
    {
        public MethodOfPayment MethodOfPayment { get; } = MethodOfPayment;
    }
}