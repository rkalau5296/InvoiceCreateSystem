namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor) : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{        
    private readonly IMapper mapper = mapper;
    private readonly IQueryExecutor queryExecutor = queryExecutor;

    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        GetProductByIdQuery query = new(request.Id);

        DataAccess.Entities.Product product = await this.queryExecutor.Execute(query);

        Domain.Models.Product mappedProduct = mapper.Map<Domain.Models.Product>(product);

        GetProductByIdResponse response = new()
        {
            Data = mappedProduct,
        };
        return response;
    }
}
