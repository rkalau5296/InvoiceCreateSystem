using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Address
{
    using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostAddressHandler : IRequestHandler<PostAddressRequest, PostAddressResponse>
    {

        private readonly IRepository<Address> addressRepository;

        public PostAddressHandler(IRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public async Task<PostAddressResponse> Handle(PostAddressRequest request, CancellationToken cancellationToken)
        {
            await addressRepository.Insert(request.Address);
            return new PostAddressResponse();
        }
    }
}
