using InvoiceCreateSystem.ApplicationServices.API.Domain;
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
    public class PutClientHandler : IRequestHandler<PutClientRequest, PutClientResponse>
    {
        private readonly IRepository<DataAccess.Entities.Client> clientRepository;

        public PutClientHandler(IRepository<DataAccess.Entities.Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<PutClientResponse> Handle(PutClientRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Client product = await this.clientRepository.GetById(request.Id);
            product.Name = request.Client.Name;
            product.AddressId = request.Client.AddressId;
            product.Email = request.Client.Email;
            product.UserId = request.Client.UserId;

            await clientRepository.Update(product);
            return new PutClientResponse();
        }
    }
}
