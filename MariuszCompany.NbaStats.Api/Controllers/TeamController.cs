using MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery;
using MariuszCompany.NbaStats.Application.Features.Teams.Queries.AllTeamsQuery;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MariuszCompany.NbaStats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private IMediator _mediator;
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(Response<IEnumerable<AllTeamsVM>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayersByTeamId()
        {
            var result = await _mediator.Send(new AllTeamsQuery());

            return Ok(result);
        }
    }
}
