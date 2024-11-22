using InvoiceCreateSystem.ApplicationServices.API.Domain.InvoicePosition;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(InvoicePosition)")]
    public class InvoicePositionController(IMediator mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInvoicePositions([FromQuery] GetInvoicePositionsRequest request)
        {
            GetInvoicePositionsResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("invoicePositionId")]
        public async Task<IActionResult> GetInvoicePositionById(int invoicePositionId)
        {
            GetInvoicePositionByIdRequest request = new(invoicePositionId);
            GetInvoicePositionByIdResponse response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostInvoicePosition([FromBody] DataAccess.Entities.InvoicePosition invoicePosition)
        {
            PostInvoicePositionRequest insertedInvoicePosition = new(invoicePosition);
            PostInvoicePositionResponse response = await mediator.Send(insertedInvoicePosition);

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateInvoicePosition(int id, [FromBody] DataAccess.Entities.InvoicePosition invoicePosition)
        {
            PutInvoicePositionRequest updatedInvoicePosition = new(id, invoicePosition);
            PutInvoicePositionResponse response = await mediator.Send(updatedInvoicePosition);

            return Ok(response);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteInvoicePosition(int id)
        {
            DeleteInvoicePositionRequest request = new(id);
            DeleteInvoicePositionResponse response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
