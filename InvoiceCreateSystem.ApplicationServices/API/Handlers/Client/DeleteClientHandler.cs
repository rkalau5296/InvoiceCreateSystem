using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientRequest, DeleteClientResponse>
    {
        private readonly IRepository<DataAccess.Entities.Client> clientRepository;

        public DeleteClientHandler(IRepository<DataAccess.Entities.Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<DeleteClientResponse> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            await clientRepository.Delete(request.Id);
            return new DeleteClientResponse();
        }
    }
}
