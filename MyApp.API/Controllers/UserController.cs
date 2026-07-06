using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.User.CreateUser;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand command, CancellationToken token)
        {
            var response = await _mediator.Send(command, token);
            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }
    }
}
