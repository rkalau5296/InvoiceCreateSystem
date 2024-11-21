﻿using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class GetInvoicePositionsHandler : IRequestHandler<GetInvoicePositionsRequest, GetInvoicePositionsResponse>
    {
        private readonly IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository;
        private readonly IMapper mapper;

        public GetInvoicePositionsHandler(IRepository<DataAccess.Entities.InvoicePosition> invoicePositionRepository, IMapper mapper)
        {
            this.invoicePositionRepository = invoicePositionRepository;
            this.mapper = mapper;
        }
        public async Task<GetInvoicePositionsResponse> Handle(GetInvoicePositionsRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.InvoicePosition> clients = await this.invoicePositionRepository.GetAll();
            IEnumerable<Domain.Models.InvoicePosition> mappedClient = this.mapper.Map<List<Domain.Models.InvoicePosition>>(clients);

            GetInvoicePositionsResponse response = new()
            {
                Data = mappedClient.ToList(),
            };

            return response;
        }
    }
}