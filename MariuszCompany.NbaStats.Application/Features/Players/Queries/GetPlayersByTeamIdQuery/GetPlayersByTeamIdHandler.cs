using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery
{
    public class GetPlayersByTeamIdHandler : IRequestHandler<GetPlayersByTeamIdQuery, Response<IEnumerable<GetPlayersByTeamIdVM>>>
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;
        public GetPlayersByTeamIdHandler(IPlayersRepository playersRepository, IMapper mapper)
        {
            _playersRepository = playersRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetPlayersByTeamIdVM>>> Handle(GetPlayersByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var players = await _playersRepository.GetByTeamIdAsync(request.TeamId!.Value);
            var playersVM = _mapper.Map<IEnumerable<GetPlayersByTeamIdVM>>(players);

            return new Response<IEnumerable<GetPlayersByTeamIdVM>>(playersVM);
        }
    }
}
