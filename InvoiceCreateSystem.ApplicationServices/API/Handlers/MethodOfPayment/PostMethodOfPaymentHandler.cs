namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

public class PostMethodOfPaymentHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostMethodOfPaymentRequest, PostMethodOfPaymentResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;
    
    public async Task<PostMethodOfPaymentResponse> Handle(PostMethodOfPaymentRequest request, CancellationToken cancellationToken)
    {
        var methodOfPayment = this.mapper.Map<MethodOfPayment>(request);
        var command = new PostMethodOfPaymentCommand() { Parametr = methodOfPayment };
        var invoiceFromDb = await commandExecutor.Execute(command);
        return new PostMethodOfPaymentResponse()
        {
            Data = this.mapper.Map<Domain.Models.MethodOfPayment>(invoiceFromDb)
        };
    }
}
