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
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressRequest, DeleteAddressResponse>
    {
        private readonly IRepository<DataAccess.Entities.Address> addressRepository;

        public DeleteAddressHandler(IRepository<DataAccess.Entities.Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<DeleteAddressResponse> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
        {
            await addressRepository.Delete(request.Id);
            return new DeleteAddressResponse();
        }
    }
}
