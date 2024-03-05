using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Commands;
using UserManagement.Domain.Entities;

namespace UserManagement.ConsumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _mediator.Send(new CreateUserCommand { User = user });
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _mediator.Send(new UpdateUserCommand { User = user });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeactivateUser(Guid id)
        {
            await _mediator.Send(new DeactivateUserCommand { Id = id });
            return Ok();
        }
    }
}
