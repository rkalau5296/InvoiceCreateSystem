using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain
{
    public class GetProductByIdRequest(int id) : IRequest<GetProductByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
