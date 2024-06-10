using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery
{
    public class GetPlayersListHandler : IRequestHandler<GetPlayersListQuery, PagedResponse<IEnumerable<GetPlayersListVM>>>
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IMapper _mapper;
        public GetPlayersListHandler(IPlayersRepository playersRepository, IMapper mapper)
        {
            _playersRepository = playersRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetPlayersListVM>>> Handle(GetPlayersListQuery request, CancellationToken cancellationToken)
        {
            var pageSize = request.PageSize ?? 25;
            var players = await _playersRepository.GetPlayersListAsync(request.Country, request.DraftYear, request.PageNumber.Value, pageSize);
            var playersVM = _mapper.Map<IEnumerable<GetPlayersListVM>>(players);

            return new PagedResponse<IEnumerable<GetPlayersListVM>>(playersVM, request.PageNumber.Value, pageSize);
        }
    }
}
