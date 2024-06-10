using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamStatsQuery
{
    public class TeamStatsQuery : IRequest<Response<TeamStatsVM>>
    {
        public Guid? TeamId { get; set; }
    }
}
