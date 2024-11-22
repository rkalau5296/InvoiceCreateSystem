using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Client> clientRepository;
        private readonly IMapper mapper;

        public GetClientsHandler(IRepository<DataAccess.Entities.Client> clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.Client> clients = await this.clientRepository.GetAll();
            IEnumerable<Domain.Models.Client> mappedClient = this.mapper.Map<List<Domain.Models.Client>>(clients);

            GetClientsResponse response = new()
            {
                Data = mappedClient.ToList(),
            };

            return response;
        }
    }
}
