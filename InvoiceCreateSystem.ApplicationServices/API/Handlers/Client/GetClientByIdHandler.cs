using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetClientByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
        {
            GetClientByIdQuery query = new(request.Id);
            DataAccess.Entities.Client client = await this.queryExecutor.Execute(query);
            Domain.Models.Client mappedClient = mapper.Map<Domain.Models.Client>(client);

            GetClientByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}
