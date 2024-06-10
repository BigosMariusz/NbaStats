using MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamStatsQuery;
using MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamWonGamesCountQuery;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MariuszCompany.NbaStats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IMediator _mediator;
        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("count-won-by-team-id")]
        [ProducesResponseType(typeof(Response<TeamWonGamesCountVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeamWonGamesCount(Guid? teamId)
        {
            var result = await _mediator.Send(new TeamWonGamesCountQuery() { TeamId = teamId });

            return Ok(result);
        }

        [HttpGet("team-stats")]
        [ProducesResponseType(typeof(Response<TeamWonGamesCountVM>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeamScoreStats(Guid? teamId)
        {
            var result = await _mediator.Send(new TeamStatsQuery() { TeamId = teamId });

            return Ok(result);
        }
    }
}
