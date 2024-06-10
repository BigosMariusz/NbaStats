using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamWonGamesCountQuery
{
    public class TeamWonGamesCountQuery : IRequest<Response<TeamWonGamesCountVM>>
    {
        public Guid? TeamId { get; set; }
    }
}
