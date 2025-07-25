namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PutMethodOfPaymentHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PutMethodOfPaymentRequest, PutMethodOfPaymentResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;   

    public async Task<PutMethodOfPaymentResponse> Handle(PutMethodOfPaymentRequest request, CancellationToken cancellationToken)
    {
        var methodOfPayment = mapper.Map<DataAccess.Entities.MethodOfPayment>(request.methodOfPayments);

        methodOfPayment.Id = request.Id;

        var command = new PutMethodOfPaymentCommand { Parametr = methodOfPayment };
        var updatedMethodOfPayment = await commandExecutor.Execute(command);

        //var domainMethodOfPayment = mapper.Map<Domain.Models.MethodOfPayment>(updatedMethodOfPayment);

        return new PutMethodOfPaymentResponse { Data = updatedMethodOfPayment };
    }
}
