using InvoiceCreateSystem.ApplicationServices.API.Domain.MethodOfPayment;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(MethodOfPayment)")]
    public class MethodOfPaymentController(IMediator mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMethodOfPayments([FromQuery] GetMethodOfPaymentRequest request)
        {
            GetMethodOfPaymentResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("methodOfPaymentId")]
        public async Task<IActionResult> GetMethodOfPaymentById(int methodOfPaymentId)
        {
            GetMethodOfPaymentByIdRequest request = new(methodOfPaymentId);
            GetMethodOfPaymentByIdResponse response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostMethodOfPayment([FromBody] DataAccess.Entities.MethodOfPayment methodOfPayment)
        {
            PostMethodOfPaymentRequest insertedMethodOfPayment = new(methodOfPayment);
            PostMethodOfPaymentResponse response = await mediator.Send(insertedMethodOfPayment);

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateMethodOfPayment(int id, [FromBody] DataAccess.Entities.MethodOfPayment methodOfPayment)
        {
            PutMethodOfPaymentRequest updatedMethodOfPayment = new(id, methodOfPayment);
            PutMethodOfPaymentResponse response = await mediator.Send(updatedMethodOfPayment);

            return Ok(response);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            DeleteMethodOfPaymentRequest request = new(id);
            DeleteMethodOfPaymentResponse response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
