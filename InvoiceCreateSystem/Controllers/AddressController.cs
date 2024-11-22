using InvoiceCreateSystem.ApplicationServices.API.Domain.Address;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(Address)")]
    public class AddressController(IMediator mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAddresses([FromQuery] GetAddressesRequest request)
        {
            GetAddressesResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("addressId")]
        public async Task<IActionResult> GetAddressById(int addressId)
        {
            GetAddressByIdRequest request = new(addressId);
            GetAddressByIdResponse response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostAddress([FromBody] DataAccess.Entities.Address address)
        {
            PostAddressRequest insertedAddress = new(address);
            PostAddressResponse response = await mediator.Send(insertedAddress);

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateAddress(int id, [FromBody] DataAccess.Entities.Address address)
        {
            PutAddressRequest updatedAddress = new(id, address);
            PutAddressResponse response = await mediator.Send(updatedAddress);

            return Ok(response);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            DeleteAddressRequest request = new(id);
            DeleteAddressResponse response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
