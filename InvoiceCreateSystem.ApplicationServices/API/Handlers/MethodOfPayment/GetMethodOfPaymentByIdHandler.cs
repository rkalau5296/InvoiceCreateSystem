namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment;

using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;
public class GetMethodOfPaymentByIdHandler(IQueryExecutor queryExecutor, IMapper mapper) : IRequestHandler<GetMethodOfPaymentByIdRequest, GetMethodOfPaymentByIdResponse>
{
    private readonly IQueryExecutor queryExecutor = queryExecutor;
    private readonly IMapper mapper = mapper;

    public async Task<GetMethodOfPaymentByIdResponse> Handle(GetMethodOfPaymentByIdRequest request, CancellationToken cancellationToken)
    {
        GetMethodOfPaymentByIdQuery query = new(request.Id);
        DataAccess.Entities.MethodOfPayment methodOfPayment = await this.queryExecutor.Execute(query);

        Domain.Models.MethodOfPayment mappedMethodOfPayment = mapper.Map<Domain.Models.MethodOfPayment>(methodOfPayment);

        GetMethodOfPaymentByIdResponse response = new()
        {
            Data = mappedMethodOfPayment,
        };

        return response;
    }
}
