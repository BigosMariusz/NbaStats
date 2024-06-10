using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using MariuszCompany.NbaStats.Domain.Entities;
using MariuszCompany.NbaStats.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Infrastructure.Repositories
{
    public class PlayersEfRepository : IPlayersRepository
    {
        private readonly NbaDbContext _dbContext;
        public PlayersEfRepository(NbaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Player>> GetByTeamIdAsync(Guid teamId)
        {
            return await _dbContext.Players.AsNoTracking().Where(x => x.TeamId == teamId).ToListAsync();
        }

        public async Task<IReadOnlyList<Player>> GetPlayersListAsync(string? country, int? draftYear, int pageNumber, int pageSize)
        {
            var query = _dbContext
                .Players
                .AsNoTracking();

            if (country != null)
            {
                query = query.Where(x => x.Country.Contains(country));
            }

            if (draftYear != null)
            {
                query = query.Where(x => x.Draft_year == draftYear);
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
