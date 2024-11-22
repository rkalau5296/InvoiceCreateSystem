using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PutMethodOfPaymentRequest(int id, MethodOfPayment methodOfPayments) : IRequest<PutMethodOfPaymentResponse>
    {
        public MethodOfPayment methodOfPayments { get; } = methodOfPayments;
        public int Id { get; set; } = id;
    }
}
