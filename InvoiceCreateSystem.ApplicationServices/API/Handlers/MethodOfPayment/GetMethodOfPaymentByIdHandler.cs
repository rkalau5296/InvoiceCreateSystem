using AutoMapper; 
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    public class GetMethodOfPaymentByIdHandler : IRequestHandler<GetMethodOfPaymentByIdRequest, GetMethodOfPaymentByIdResponse>
    {
        private readonly IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository;
        private readonly IMapper mapper;

        public GetMethodOfPaymentByIdHandler(IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository, IMapper mapper)
        {
            this.methodOfPaymentRepository = methodOfPaymentRepository;
            this.mapper = mapper;
        }
        public async Task<GetMethodOfPaymentByIdResponse> Handle(GetMethodOfPaymentByIdRequest request, CancellationToken cancellationToken)
        {
            DataAccess.Entities.MethodOfPayment client = await this.methodOfPaymentRepository.GetById(request.Id);
            Domain.Models.MethodOfPayment mappedClient = mapper.Map<Domain.Models.MethodOfPayment>(client);

            GetMethodOfPaymentByIdResponse response = new()
            {
                Data = mappedClient,
            };

            return response;
        }
    }
}
