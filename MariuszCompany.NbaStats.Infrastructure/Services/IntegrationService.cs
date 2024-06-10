using AutoMapper;
using MariuszCompany.NbaStats.Application.Interfaces;
using MariuszCompany.NbaStats.Domain.Entities;
using MariuszCompany.NbaStats.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Infrastructure.Services
{
    public class IntegrationService : IIntegrationService
    {
        private readonly ILogger<IntegrationService> _logger;
        private readonly IMapper _mapper;
        private readonly INbaApiClient _apiClient;
        private readonly NbaDbContext _nbaDbContext;

        public IntegrationService(ILogger<IntegrationService> logger, INbaApiClient apiClient, NbaDbContext nbaDbContext, IMapper mapper)
        {
            _logger = logger;
            _apiClient = apiClient;
            _nbaDbContext = nbaDbContext;
            _mapper = mapper;
        }

        public async Task Import()
        {
            try
            {
                // If we have downloaded data in the database, we no longer synchronize.
                // In the real world, we would probably want to add delta changes periodically but this application is just a demonstration.
                if (await _nbaDbContext.IntegrationProcesses.AnyAsync(x => x.Success == true))
                {
                    return;
                }

                var integrationProcess = new IntegrationProcess
                {
                    StartDateUtc = DateTime.UtcNow
                };

                await _nbaDbContext.AddAsync(integrationProcess);
                await _nbaDbContext.SaveChangesAsync();

                try
                {
                    var teamsTask = _apiClient.GetAllTeams();
                    var gamesTask = _apiClient.GetGames();
                    var playersTask = _apiClient.GetPlayers();

                    var teams = await teamsTask;
                    var games = await gamesTask;  
                    var players = await playersTask;

                    var dbTeams = _mapper.Map<List<Team>>(teams);
                    var dbGames = _mapper.Map<List<Game>>(games);
                    var dbPlayers = _mapper.Map<List<Player>>(players);

                    foreach (var game in dbGames)
                    {
                        game.VisitorTeamId = dbTeams.SingleOrDefault(x => x.IntegrationId == game.VisitorTeamIntegrationId)?.Id;
                        game.HomeTeamId = dbTeams.SingleOrDefault(x => x.IntegrationId == game.HomeTeamIntegrationId)?.Id;
                    }

                    foreach (var player in dbPlayers)
                    {
                        player.TeamId = dbTeams.SingleOrDefault(x => x.IntegrationId == player.TeamIntegrationId)?.Id;
                    }

                    await _nbaDbContext.AddRangeAsync(dbTeams);
                    await _nbaDbContext.AddRangeAsync(dbGames);
                    await _nbaDbContext.AddRangeAsync(dbPlayers);

                    await _nbaDbContext.SaveChangesAsync();

                    integrationProcess.EndDateUtc = DateTime.UtcNow;
                    integrationProcess.Success = true;
                    await _nbaDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    integrationProcess.ErrorMessage = $"Message: {ex.Message}, InnerExceptionMessage: {ex.InnerException?.Message}, Stack trace: {ex.StackTrace}";
                    integrationProcess.Success = false;
                    await _nbaDbContext.SaveChangesAsync();

                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw;
            }
        }
    }
}
