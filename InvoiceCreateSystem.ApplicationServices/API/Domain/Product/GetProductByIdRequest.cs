using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Domain.Product
{
    public class GetProductByIdRequest(int id) : IRequest<GetProductByIdResponse>
    {
        public int Id { get; set; } = id;
    }
}
