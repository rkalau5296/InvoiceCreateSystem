using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment
{
    public class DeleteMethodOfPaymentRequest(int id) : IRequest<DeleteMethodOfPaymentResponse>
    {
        public int Id { get; } = id;
    }
}