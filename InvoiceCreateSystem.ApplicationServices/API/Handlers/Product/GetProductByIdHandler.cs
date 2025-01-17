using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {        
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        public GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {            
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductQuery();
            
            var product = await this.queryExecutor.Execute(query);

            Domain.Models.Product mappedProduct = mapper.Map<Domain.Models.Product>(product);

            GetProductByIdResponse response = new()
            {
                Data = mappedProduct,
            };
            return response;
        }
    }
}
