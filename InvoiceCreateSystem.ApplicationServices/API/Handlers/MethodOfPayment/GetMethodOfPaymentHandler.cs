using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.MethodOfPayment
{
    public class GetMethodOfPaymentHandler : IRequestHandler<GetMethodOfPaymentRequest, GetMethodOfPaymentResponse>
    {
        private readonly IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository;
        private readonly IMapper mapper;

        public GetMethodOfPaymentHandler(IRepository<DataAccess.Entities.MethodOfPayment> methodOfPaymentRepository, IMapper mapper)
        {
            this.methodOfPaymentRepository = methodOfPaymentRepository;
            this.mapper = mapper;
        }
        public async Task<GetMethodOfPaymentResponse> Handle(GetMethodOfPaymentRequest request, CancellationToken cancellationToken)
        {
            List<DataAccess.Entities.MethodOfPayment> clients = await this.methodOfPaymentRepository.GetAll();
            IEnumerable<Domain.Models.MethodOfPayment> mappedClient = this.mapper.Map<List<Domain.Models.MethodOfPayment>>(clients);

            GetMethodOfPaymentResponse response = new()
            {
                Data = mappedClient.ToList(),
            };

            return response;
        }
    }
}
