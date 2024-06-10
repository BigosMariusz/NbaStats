using System;
using System.Collections.Generic;
using System.Text;

namespace MariuszCompany.NbaStats.Application.Features.Players.Queries.GetPlayersByTeamIdQuery
{
    public class GetPlayersListVM
    {
        public Guid Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Position { get; set; }
        public string? Jersey_number { get; set; }
        public string? Country { get; set; }
        public int? Draft_year { get; set; }
        public int? Weight { get; set; }
    }
}
