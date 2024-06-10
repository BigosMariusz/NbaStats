using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariuszCompany.NbaStats.Application.Features.Games.Queries.TeamStatsQuery
{
    public class TeamStatsVM
    {
        public decimal AvgScore { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
    }
}
