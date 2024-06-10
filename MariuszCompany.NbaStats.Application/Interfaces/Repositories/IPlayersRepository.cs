using MariuszCompany.NbaStats.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Interfaces.Repositories
{
    public interface IPlayersRepository
    {
        Task<IReadOnlyList<Player>> GetByTeamIdAsync(Guid teamId);
        Task<IReadOnlyList<Player>> GetPlayersListAsync(string? country, int? draftYear, int pageNumber, int pageSize);
    }
}
