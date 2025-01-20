using AutoMapper; 
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS.Queries;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    public class GetMethodOfPaymentByIdHandler : IRequestHandler<GetMethodOfPaymentByIdRequest, GetMethodOfPaymentByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetMethodOfPaymentByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
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
}
