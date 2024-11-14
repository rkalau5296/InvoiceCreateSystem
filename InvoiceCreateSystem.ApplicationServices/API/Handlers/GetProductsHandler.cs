using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;
        public GetProductsHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<DataAccess.Entities.Product> products = productRepository.GetAll();

            IEnumerable<Product> domainProducts = products.Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value
            });
            GetProductsResponse response = new()
            {
                Data = domainProducts.ToList(),
            };

            return Task.FromResult(response);
        }
    }
}
