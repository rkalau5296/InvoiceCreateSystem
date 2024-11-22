using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice
{
    public class GetInvoiceByIdRequest(int id) : IRequest<GetInvoiceByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
