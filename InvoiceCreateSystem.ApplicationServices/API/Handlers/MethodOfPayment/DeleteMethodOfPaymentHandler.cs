using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    public class DeleteMethodOfPaymentHandler(ICommandExecutor commandExecutor) : IRequestHandler<DeleteMethodOfPaymentRequest, DeleteMethodOfPaymentResponse>
    {
        private readonly ICommandExecutor commandExecutor = commandExecutor;        

        public async Task<DeleteMethodOfPaymentResponse> Handle(DeleteMethodOfPaymentRequest request, CancellationToken cancellationToken)
        {
            var methodOfPayment = new DataAccess.Entities.MethodOfPayment { Id = request.Id };

            var command = new DeleteMethodOfPaymentCommand { Parametr = methodOfPayment };
            await commandExecutor.Execute(command);
            return new DeleteMethodOfPaymentResponse();
        }
    }
}
