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
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;
        public GetProductsHandler(IRepository<DataAccess.Entities.Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = productRepository.GetAll();

            var domainProducts = products.Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value
            });
            var response = new GetProductsResponse()
            {
                Data = domainProducts.ToList(),
            };

            return Task.FromResult(response);
        }
    }
}
