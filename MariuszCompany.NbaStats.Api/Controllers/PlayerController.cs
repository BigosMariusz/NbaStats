using MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery;
using MariuszCompany.NbaStats.Application.Responses;
using MariuszCompany.NbaStats.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MariuszCompany.NbaStats.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IMediator _mediator;
        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("byteam-id")]
        [ProducesResponseType(typeof(Response<List<GetPlayersByTeamIdVM>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayersByTeamId(Guid? teamId)
        {
            var result = await _mediator.Send(new GetPlayersByTeamIdQuery() { TeamId = teamId });

            return Ok(result);
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(PagedResponse<List<GetPlayersByTeamIdVM>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList(string? country, int? draftYear, int? pageNumber, int? pageSize)
        {
            var result = await _mediator.Send(new GetPlayersListQuery() 
            {
                Country = country, DraftYear = draftYear, PageNumber = pageNumber, PageSize = pageSize
            });

            return Ok(result);
        }
    }
}
