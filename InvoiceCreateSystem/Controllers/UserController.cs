using InvoiceCreateSystem.ApplicationServices.API.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceCreateSystem.Controllers
{
    [ApiController]
    [Route("(User)")]
    public class UserController(IMediator mediator) : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            GetUsersResponse response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("userId")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            GetUserByIdRequest request = new(userId);
            GetUserByIdResponse response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> PostUser([FromBody] DataAccess.Entities.User user)
        {
            PostUserRequest insertedUser = new(user);
            PostUserResponse response = await mediator.Send(insertedUser);

            return Ok(response);
        }

        [HttpPut]
        [Route("update/id")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] DataAccess.Entities.User user)
        {
            PutUserRequest updatedUser = new(id, user);
            PutUserResponse response = await mediator.Send(updatedUser);

            return Ok(response);
        }

        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            DeleteUserRequest request = new(id);
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
