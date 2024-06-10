using MariuszCompany.NbaStats.Domain.Common;
using System.Text.RegularExpressions;

namespace MariuszCompany.NbaStats.Domain.Entities
{
    public class Team : AuditableBaseEntity
    {
        public int IntegrationId { get; set; }
        public string? Conference { get; set; }
        public string? Division { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Full_name { get; set; }
        public string? Abbreviation { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public ICollection<Game> HomeGames { get; set; }
        public ICollection<Game> VisitorGames { get; set; }

    }
}
