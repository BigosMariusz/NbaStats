using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamWonGamesCountQuery
{
    public class TeamWonGamesCountHandler : IRequestHandler<TeamWonGamesCountQuery, Response<TeamWonGamesCountVM>>
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;
        public TeamWonGamesCountHandler(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public async Task<Response<TeamWonGamesCountVM>> Handle(TeamWonGamesCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _gamesRepository.GetTeamWonGamesCountAsync(request.TeamId!.Value);
            var vm = _mapper.Map<TeamWonGamesCountVM>(count);

            return new Response<TeamWonGamesCountVM>(vm);
        }
    }
}
