using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address
{
    public class PutAddressHandler : IRequestHandler<PutAddressRequest, PutAddressResponse>
    {
        private readonly IRepository<DataAccess.Entities.Address> addressRepository;

        public PutAddressHandler(IRepository<DataAccess.Entities.Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<PutAddressResponse> Handle(PutAddressRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.Address address = await this.addressRepository.GetById(request.Id);
            address.Street = request.Address.Street;
            address.Number = request.Address.Number;
            address.City = request.Address.City;
            address.PostalCode = request.Address.PostalCode;

            await addressRepository.Update(address);
            return new PutAddressResponse();
        }
    }
}
