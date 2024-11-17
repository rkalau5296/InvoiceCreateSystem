using InvoiceCreateSystem.ApplicationServices.API.Domain;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(Product)")]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            GetProductsResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("productId")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            GetProductByIdRequest request = new (productId);
            GetProductByIdResponse response = await mediator.Send(request);           

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostProduct([FromBody] DataAccess.Entities.Product product)
        {
            PostProductRequest insertedProduct = new(product);
            PostProductResponse response = await mediator.Send(insertedProduct);           

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] DataAccess.Entities.Product product)
        {
            PutProductRequest updatedProduct = new(id, product);
            PutProductResponse response = await mediator.Send(updatedProduct);

            return Ok(response);
        }
    }
}