using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition
{
    public class GetInvoicePositionByIdRequest(int id) : IRequest<GetInvoicePositionByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
