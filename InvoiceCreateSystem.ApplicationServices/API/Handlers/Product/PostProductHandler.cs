using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Product;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers.Product
{
    public class PostProductHandler : IRequestHandler<PostProductRequest, PostProductResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;

        public PostProductHandler(IRepository<DataAccess.Entities.Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
        }

        public async Task<PostProductResponse> Handle(PostProductRequest request, CancellationToken cancellationToken)
        {
            await productRepository.Insert(request.Product);
            return new PostProductResponse();
        }
    }
}
