using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Branch.CreateBranch;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/branch")]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranchAsync(CreateBranchCommand command, CancellationToken token)
        {
            var response = await _mediator.Send(command, token);
            if (!response.isSuccess) return BadRequest(response);

            return Ok(response);
        }
    }
}
