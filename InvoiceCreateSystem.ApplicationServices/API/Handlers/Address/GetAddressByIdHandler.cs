using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address
{
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdRequest, GetAddressByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAddressByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetAddressByIdResponse> Handle(GetAddressByIdRequest request, CancellationToken cancellationToken)
        {
            GetAddressByIdQuery query = new(request.Id);
            DataAccess.Entities.Address address = await this.queryExecutor.Execute(query);
            Domain.Models.Address mappedClient = mapper.Map<Domain.Models.Address>(address);

            GetAddressByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}
