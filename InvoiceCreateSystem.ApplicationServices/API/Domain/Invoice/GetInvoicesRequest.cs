using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice
{
    public class GetInvoicesRequest : IRequest<GetInvoicesResponse>
    {
    }
}
