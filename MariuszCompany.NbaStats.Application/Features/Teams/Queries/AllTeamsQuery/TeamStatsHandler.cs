using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Features.Teams.Queries.AllTeamsQuery
{
    public class TeamStatsHandler : IRequestHandler<AllTeamsQuery, Response<IEnumerable<AllTeamsVM>>>
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IMapper _mapper;
        public TeamStatsHandler(ITeamsRepository teamsRepository, IMapper mapper)
        {
            _teamsRepository = teamsRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<AllTeamsVM>>> Handle(AllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamsRepository.GetAllAsync();
            var vm = _mapper.Map<IEnumerable<AllTeamsVM>>(teams);

            return new Response<IEnumerable<AllTeamsVM>>(vm);
        }
    }
}
