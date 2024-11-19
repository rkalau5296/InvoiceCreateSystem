using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdRequest, GetClientByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.Client> clientRepository;
        private readonly IMapper mapper;

        public GetClientByIdHandler(IRepository<DataAccess.Entities.Client> clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }
        public async Task<GetClientByIdResponse> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Client client = await this.clientRepository.GetById(request.Id);
            Domain.Models.Client mappedClient = mapper.Map<Domain.Models.Client>(client);

            GetClientByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}
