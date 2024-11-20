using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;
        private readonly IMapper mapper;

        public GetProductsHandler(IRepository<DataAccess.Entities.Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.Product> products = await productRepository.GetAll();
            IEnumerable<Domain.Models.Product> mappedProduct = mapper.Map<List<Domain.Models.Product>>(products);

            GetProductsResponse response = new()
            {
                Data = mappedProduct.ToList(),
            };

            return response;
        }
    }
}
