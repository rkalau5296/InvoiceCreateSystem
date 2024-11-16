using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;
        private readonly IMapper mapper;
        public GetProductByIdHandler(IRepository<DataAccess.Entities.Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Product product = await this.productRepository.GetById(request.Id);

            Domain.Models.Product mappedProduct = this.mapper.Map<Domain.Models.Product>(product);

            GetProductByIdResponse response = new()
            {
                Data = mappedProduct,
            };
            return response;
        }
    }
}
