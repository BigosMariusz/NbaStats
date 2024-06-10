using MariuszCompany.NbaStats.Application.Dto.NbaIntegration;

namespace MariuszCompany.NbaStats.Application.Interfaces
{
    public interface INbaApiClient
    {
        Task<List<NbaTeam>> GetAllTeams();
        Task<List<NbaGame>> GetGames();
        Task<List<NbaPlayer>> GetPlayers();
    }
}