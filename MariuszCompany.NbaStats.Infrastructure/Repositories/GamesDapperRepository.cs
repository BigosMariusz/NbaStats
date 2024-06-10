using Dapper;
using MariuszCompany.NbaStats.Application.Data;
using MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamStatsQuery;
using MariuszCompany.NbaStats.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Infrastructure.Repositories
{
    public class GamesDapperRepository : IGamesRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public GamesDapperRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<TeamStatsVM> GetTeamGamesStatsAsync(Guid teamId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = $"""
                                SELECT 
                                    AVG(Score) AS AvgScore,
                                    MAX(Score) AS MaxScore,
                                    MIN(Score) AS MinScore
                                FROM (
                                    SELECT 
                                        g.Home_team_score AS Score
                                    FROM 
                                        [Games] g
                                    WHERE 
                                        g.HomeTeamId = @TeamId
                                    UNION ALL
                                    SELECT 
                                        g.Visitor_team_score AS Score
                                    FROM 
                                        [Games] g
                                    WHERE 
                                        g.VisitorTeamId = @TeamId
                                ) AS Results
                                """;

            var result = await connection.QuerySingleOrDefaultAsync<TeamStatsVM>(sql, new { TeamId = teamId });

            return result ?? new TeamStatsVM();
        }

        public async Task<int> GetTeamWonGamesCountAsync(Guid teamId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = $"""
                                SELECT 
                                    COUNT(*) AS WinsCount
                                FROM (
                                    SELECT 
                                        HomeTeamId AS TeamId
                                    FROM 
                                        [Games] g
                                    WHERE 
                                        g.Home_team_score > g.Visitor_team_score
                                    UNION ALL
                                    SELECT 
                                        VisitorTeamId AS TeamId
                                    FROM 
                                        [Games] g
                                    WHERE 
                                        g.Visitor_team_score > g.Home_team_score
                                ) AS Wins
                                WHERE TeamId = @TeamId
                                GROUP BY TeamId
                                """;

            var result =  await connection.QuerySingleOrDefaultAsync<int?>(sql, new { TeamId = teamId });

            return result ?? 0;
        }
    }
}
