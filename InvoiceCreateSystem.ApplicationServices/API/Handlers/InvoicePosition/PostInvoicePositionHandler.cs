namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

public class PostInvoicePositionHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostInvoicePositionRequest, PostInvoicePositionResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;    

    public async Task<PostInvoicePositionResponse> Handle(PostInvoicePositionRequest request, CancellationToken cancellationToken)
    {
        var invoicePosition = this.mapper.Map<InvoicePosition>(request);
        var command = new PostInvoicePositionCommand() { Parametr = invoicePosition };
        var invoiceFromDb = await commandExecutor.Execute(command);
        return new PostInvoicePositionResponse()
        {
            Data = this.mapper.Map<Domain.Models.InvoicePosition>(invoiceFromDb)
        };
    }
}
