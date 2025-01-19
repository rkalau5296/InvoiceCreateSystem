using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            GetProductsQuery query = new();
            List<DataAccess.Entities.Product> products = await queryExecutor.Execute(query);
            IEnumerable<Domain.Models.Product> mappedProduct = mapper.Map<List<Domain.Models.Product>>(products);

            GetProductsResponse response = new()
            {
                Data = mappedProduct.ToList(),
            };

            return response;
        }
    }
}
