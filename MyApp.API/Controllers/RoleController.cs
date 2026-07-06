using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Role.CreateRole;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoleAsync(CreateRoleCommand command, CancellationToken token)
        {
            var response = await _mediator.Send(command, token);
            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }
    }
}
