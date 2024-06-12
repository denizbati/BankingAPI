using MediatR;
using Microsoft.AspNetCore.Mvc;
using platform.empty.ApiContract.Request.Queries;

namespace platform.empty.API.Controllers
{
    [Route("index")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndexController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Healthcheck
        /// </summary>
        [HttpGet("healthcheck")]
        [ProducesResponseType(200, Type = typeof(int))]
        public async Task<IActionResult> HealthCheck(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new HealthCheckQuery(), cancellationToken);
            return Ok(response);
        }
    }
}
