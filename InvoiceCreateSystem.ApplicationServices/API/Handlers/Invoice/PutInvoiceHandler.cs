namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Invoice;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PutInvoiceHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PutInvoiceRequest, PutInvoiceResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;    

    public async Task<PutInvoiceResponse> Handle(PutInvoiceRequest request, CancellationToken cancellationToken)
    {
        var invoice = mapper.Map<DataAccess.Entities.Invoice>(request.invoice);

        invoice.Id = request.Id;

        var command = new PutInvoiceCommand { Parametr = invoice };
        var updatedInvoice = await commandExecutor.Execute(command);

        var domainInvoice = mapper.Map<Domain.Models.Invoice>(updatedInvoice);

        return new PutInvoiceResponse { Data = domainInvoice };
    }
}
