using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using InvoiceCreateSystem.DataAccess;
using MediatR;

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
