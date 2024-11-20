using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    public class PutProductHandler : IRequestHandler<PutProductRequest, PutProductResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;

        public PutProductHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<PutProductResponse> Handle(PutProductRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Product product = await productRepository.GetById(request.Id);
            product.Name = request.Product.Name;
            product.Value = request.Product.Value;

            await productRepository.Update(product);
            return new PutProductResponse();
        }
    }
}
