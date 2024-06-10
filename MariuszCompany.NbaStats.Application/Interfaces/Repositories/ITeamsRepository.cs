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
    public interface ITeamsRepository
    {
        Task<IReadOnlyList<Team>> GetAllAsync();
    }
}
