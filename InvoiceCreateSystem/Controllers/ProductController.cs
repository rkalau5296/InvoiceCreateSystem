using InvoiceCreateSystem.ApplicationServices.API.Domain;
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
    }
}