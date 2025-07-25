namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.InvoicePosition;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;
public class PutInvoicePositionHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PutInvoicePositionRequest, PutInvoicePositionResponse>
{
    private readonly ICommandExecutor commandExecutor = commandExecutor;
    private readonly IMapper mapper = mapper;
    public async Task<PutInvoicePositionResponse> Handle(PutInvoicePositionRequest request, CancellationToken cancellationToken)
    {
        var invoicePosition = mapper.Map<DataAccess.Entities.InvoicePosition>(request.invoicePosition);

        invoicePosition.Id = request.Id;

        var command = new PutInvoicePositionCommand { Parametr = invoicePosition };
        var updatedInvoicePosition = await commandExecutor.Execute(command);

        var domainInvoicePosition = mapper.Map<Domain.Models.InvoicePosition>(updatedInvoicePosition);

        return new PutInvoicePositionResponse { Data = domainInvoicePosition };
    }
}
