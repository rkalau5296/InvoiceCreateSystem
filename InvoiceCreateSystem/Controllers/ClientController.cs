using InvoiceCreateSystem.ApplicationServices.API.Domain.Client;
using InvoiceCreateSystem.ApplicationServices.API.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(Client)")]
    public class ClientController(IMediator mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllClients([FromQuery] GetClientsRequest request)
        {
            GetClientsResponse response = await mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet]
        [Route("clientId")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            GetClientByIdRequest request = new(clientId);
            GetClientByIdResponse response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostClient([FromBody] DataAccess.Entities.Client client)
        {
            PostClientRequest insertedClient = new(client);
            PostClientResponse response = await mediator.Send(insertedClient);

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] DataAccess.Entities.Client client)
        {
            PutClientRequest updatedClient = new(id, client);
            PutClientResponse response = await mediator.Send(updatedClient);

            return Ok(response);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            DeleteClientRequest request = new(id);
            DeleteClientResponse response = await mediator.Send(request);

            return Ok(response);
        }

    }
}
