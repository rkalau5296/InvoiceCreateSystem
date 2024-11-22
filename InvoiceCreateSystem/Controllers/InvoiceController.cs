using InvoiceCreateSystem.ApplicationServices.API.Domain.Invoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(Invoice)")]
    public class InvoiceController(IMediator mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInvoices([FromQuery] GetInvoicesRequest request)
        {
            GetInvoicesResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("invoiceId")]
        public async Task<IActionResult> GetInvoiceById(int invoiceId)
        {
            GetInvoiceByIdRequest request = new(invoiceId);
            GetInvoiceByIdResponse response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostInvoice([FromBody] DataAccess.Entities.Invoice invoice)
        {
            PostInvoiceRequest insertedInvoice = new(invoice);
            PostInvoiceResponse response = await mediator.Send(insertedInvoice);

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] DataAccess.Entities.Invoice invoice)
        {
            PutInvoiceRequest updatedInvoice = new(id, invoice);
            PutInvoiceResponse response = await mediator.Send(updatedInvoice);

            return Ok(response);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            DeleteInvoiceRequest request = new(id);
            DeleteInvoiceResponse response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
