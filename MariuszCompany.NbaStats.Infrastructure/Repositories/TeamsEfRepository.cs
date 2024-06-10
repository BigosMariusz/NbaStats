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
    public class TeamsEfRepository : ITeamsRepository
    {
        private readonly NbaDbContext _dbContext;
        public TeamsEfRepository(NbaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Team>> GetAllAsync()
        {
            return await _dbContext.Teams.AsNoTracking().ToListAsync();
        }
    }
}
