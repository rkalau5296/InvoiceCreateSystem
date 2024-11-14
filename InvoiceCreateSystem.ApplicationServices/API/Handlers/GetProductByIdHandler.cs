using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using InvoiceCreateSystem.DataAccess;
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
        public GetProductByIdHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Product product = productRepository.GetById(request.Id);

            Product domainProduct = new()
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value
            };
            GetProductByIdResponse response = new()
            {
                Data = domainProduct,
            };
            return Task.FromResult(response);
        }
    }
}
