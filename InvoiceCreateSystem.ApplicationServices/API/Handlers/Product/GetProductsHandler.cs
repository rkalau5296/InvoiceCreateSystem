namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    using AutoMapper;
    using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
    using InvoiceCreateSystem.DataAccess.CQRS;
    using InvoiceCreateSystem.DataAccess.CQRS.Queries;
    using MediatR;
    public class GetProductsHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IQueryExecutor queryExecutor = queryExecutor;
        private readonly IMapper mapper = mapper;

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            GetProductsQuery query = new();
            List<DataAccess.Entities.Product> products = await queryExecutor.Execute(query);
            IEnumerable<Domain.Models.Product> mappedProduct = mapper.Map<List<Domain.Models.Product>>(products);

            GetProductsResponse response = new()
            {
                Data = [.. mappedProduct],
            };

            return response;
        }
    }
}
