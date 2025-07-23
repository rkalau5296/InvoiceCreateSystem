namespace InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;

using InvoiceCreateSystem.DataAccess.Entities;
using MediatR;
public class PutInvoicePositionRequest(int id, InvoicePosition invoicePosition) : IRequest<PutInvoicePositionResponse>
{
    public InvoicePosition invoicePosition { get; } = invoicePosition;
    public int Id { get; set; } = id;
}
