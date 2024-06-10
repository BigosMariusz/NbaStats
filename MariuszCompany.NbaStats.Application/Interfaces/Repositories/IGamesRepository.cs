using MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamStatsQuery;
using MariuszCompany.NbaStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Interfaces.Repositories
{
    public interface IGamesRepository
    {
        Task<int> GetTeamWonGamesCountAsync(Guid teamId);
        Task<TeamStatsVM> GetTeamGamesStatsAsync(Guid teamId);
    }
}
