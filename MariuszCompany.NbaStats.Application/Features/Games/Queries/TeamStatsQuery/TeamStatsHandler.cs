using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamStatsQuery
{
    public class TeamStatsHandler : IRequestHandler<TeamStatsQuery, Response<TeamStatsVM>>
    {
        private readonly IGamesRepository _gamesRepository;
        public TeamStatsHandler(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<Response<TeamStatsVM>> Handle(TeamStatsQuery request, CancellationToken cancellationToken)
        {
            var vm = await _gamesRepository.GetTeamGamesStatsAsync(request.TeamId!.Value);

            return new Response<TeamStatsVM>(vm);
        }
    }
}
