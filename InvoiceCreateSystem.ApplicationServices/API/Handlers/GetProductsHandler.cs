using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers
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
            List<DataAccess.Entities.Product> products = await this.productRepository.GetAll();
            IEnumerable<Domain.Models.Product> mappedProduct = this.mapper.Map<List<Domain.Models.Product>>(products);
            
            GetProductsResponse response = new()
            {
                Data = mappedProduct.ToList(),
            };

            return response;
        }
    }
}
