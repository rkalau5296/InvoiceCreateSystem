using InvoiceCreateSystem.DataAccess;
using InvoiceCreateSystem.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(controller)")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Product> GetAllProducts() => productRepository.GetAll();

        [HttpGet]
        [Route("productId")]
        public Product GetProductById(int productId) => productRepository.GetById(productId);

    }
}
