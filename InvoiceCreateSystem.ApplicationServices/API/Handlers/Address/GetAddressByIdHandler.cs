﻿using AutoMapper;
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
    public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdRequest, GetAddressByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.Address> addressRepository;
        private readonly IMapper mapper;

        public GetAddressByIdHandler(IRepository<DataAccess.Entities.Address> addressRepository, IMapper mapper)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }
        public async Task<GetAddressByIdResponse> Handle(GetAddressByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Address address = await this.addressRepository.GetById(request.Id);
            Domain.Models.Address mappedClient = mapper.Map<Domain.Models.Address>(address);

            GetAddressByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}