namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetMethodOfPaymentHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetMethodOfPaymentRequest, GetMethodOfPaymentResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetMethodOfPaymentResponse> Handle(GetMethodOfPaymentRequest request, CancellationToken cancellationToken)
    {
        GetMethodOfPaymentsQuery query = new();
        List<DataAccess.Entities.MethodOfPayment> clients = await this.queryExecutor.Execute(query);
        IEnumerable<Domain.Models.MethodOfPayment> mappedClient = this.mapper.Map<List<Domain.Models.MethodOfPayment>>(clients);

        GetMethodOfPaymentResponse response = new()
        {
            Data = mappedClient.ToList(),
        };

        return response;
    }
}
