namespace MariuszCompany.NbaStats.Application.Dto.NbaIntegration
{
    public class NbaGame
    {
        public int Id { get; set; }
        public DateOnly? Date { get; set; }
        public int? Season { get; set; }
        public string? Status { get; set; }
        public bool? Postseason { get; set; }
        public int? Home_team_score { get; set; }
        public int? Visitor_team_score { get; set; }
        public NbaTeam? Home_team { get; set; }
        public NbaTeam? Visitor_team { get; set; }
    }
}
