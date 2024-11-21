using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address
{
    public class GetAddressesHandler : IRequestHandler<GetAddressesRequest, GetAddressesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Address> addressRepository;
        private readonly IMapper mapper;

        public GetAddressesHandler(IRepository<DataAccess.Entities.Address> addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }
        public async Task<GetAddressesResponse> Handle(GetAddressesRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.Address> addresses = await this.addressRepository.GetAll();
            IEnumerable<Domain.Models.Address> mappedClient = this.mapper.Map<List<Domain.Models.Address>>(addresses);

            GetAddressesResponse response = new()
            {
                Data = mappedClient.ToList(),
            };

            return response;
        }
    }
}
