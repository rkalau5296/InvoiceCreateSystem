namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;

public class PostInvoiceHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PostInvoiceRequest, PostInvoiceResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;   

    public async Task<PostInvoiceResponse> Handle(PostInvoiceRequest request, CancellationToken cancellationToken)
    {
        var invoice = this.mapper.Map<Invoice>(request);
        var command = new PostInvoiceCommand() { Parametr = invoice };
        var invoiceFromDb = await commandExecutor.Execute(command);
        return new PostInvoiceResponse()
        {
            Data = this.mapper.Map<Domain.Models.Invoice>(invoiceFromDb)
        };
    }
}
