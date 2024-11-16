using AutoMapper;
using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.DataAccess;
using MediatR;

namespace InvoiceCreateSystem.ApplicationServices.API.Handlers
{
    public class PostProductHandler : IRequestHandler<PostProductRequest, PostProductResponse>
    {
        private readonly IRepository<DataAccess.Entities.Product> productRepository;
        private readonly IMapper mapper;

        public PostProductHandler(IRepository<DataAccess.Entities.Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<PostProductResponse> Handle(PostProductRequest request, CancellationToken cancellationToken)
        {
            await productRepository.Insert(request.Product);
            return new PostProductResponse();
        }
    }
}
