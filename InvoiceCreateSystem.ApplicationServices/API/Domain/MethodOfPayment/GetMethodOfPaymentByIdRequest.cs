using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment
{
    public class GetMethodOfPaymentByIdRequest(int id) : IRequest<GetMethodOfPaymentByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
