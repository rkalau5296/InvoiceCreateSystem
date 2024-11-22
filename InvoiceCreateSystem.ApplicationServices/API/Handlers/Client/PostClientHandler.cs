using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    using InvoiceCreateSystem.DataAccess.Entities;
    public class PostClientHandler : IRequestHandler<PostClientRequest, PostClientResponse>
    {

        private readonly IRepository<Client> clientRepository;

        public PostClientHandler(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<PostClientResponse> Handle(PostClientRequest request, CancellationToken cancellationToken)
        {
            await clientRepository.Insert(request.Client);
            return new PostClientResponse();
        }
    }
}
