using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.CQRS;
using InvoiceCreateSystem.DataAccess.CQRS.Commands;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    public class PutProductHandler(ICommandExecutor commandExecutor, IMapper mapper) : IRequestHandler<PutProductRequest, PutProductResponse>
    {
        private readonly ICommandExecutor commandExecutor = commandExecutor;
        private readonly IMapper mapper = mapper;        

        public async Task<PutProductResponse> Handle(PutProductRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<DataAccess.Entities.Product>(request.Product);

            product.Id = request.Id;

            var command = new PutProductCommand { Parametr = product };
            var updatedProduct = await commandExecutor.Execute(command);

            //var domainMethodOfPayment = mapper.Map<Domain.Models.MethodOfPayment>(updatedMethodOfPayment);

            return new PutProductResponse { Data = updatedProduct };
        }
    }
}
