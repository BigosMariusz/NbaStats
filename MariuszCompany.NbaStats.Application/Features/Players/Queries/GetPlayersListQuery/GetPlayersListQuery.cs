using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery
{
    public class GetPlayersListQuery : IRequest<PagedResponse<IEnumerable<GetPlayersListVM>>>
    {
        public string? Country { get; set; }
        public int? DraftYear { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; } 
    }
}
