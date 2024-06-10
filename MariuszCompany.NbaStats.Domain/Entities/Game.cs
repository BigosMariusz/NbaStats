using MariuszCompany.NbaStats.Domain.Common;

namespace MariuszCompany.NbaStats.Domain.Entities
{
    public class Game : AuditableBaseEntity
    {
        public int IntegrationId { get; set; }
        public DateOnly? Date { get; set; }
        public int? Season { get; set; }
        public string? Status { get; set; }
        public bool? Postseason { get; set; }
        public int? Home_team_score { get; set; }
        public int? Visitor_team_score { get; set; }
        public int? HomeTeamIntegrationId { get; set; }
        public int? VisitorTeamIntegrationId { get; set; }
        public Guid? HomeTeamId { get; set; }
        public Guid? VisitorTeamId { get; set; }
        public virtual Team? HomeTeam { get; set; }
        public virtual Team? VisitorTeam { get; set; }
    }
}
