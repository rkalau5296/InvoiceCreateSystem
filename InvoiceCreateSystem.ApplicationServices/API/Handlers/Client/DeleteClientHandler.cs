using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Client
{
    public class DeleteClientHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteClientRequest, DeleteClientResponse>
    {
        private readonly ICommandExecutor commandExecutor = commandExecutor;
        
        public async Task<DeleteClientResponse> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var client = new DataAccess.Entities.Client { Id = request.Id };

            var command = new DeleteClientCommand { Parametr = client };
            await commandExecutor.Execute(command);
            return new DeleteClientResponse();
        }
    }
}
