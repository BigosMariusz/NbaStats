namespace MariuszCompany.NbaStats.Application.Dto.NbaIntegration
{
    public class NbaPlayer
    {
        public int Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Position { get; set; }
        public string? Jersey_number { get; set; }
        public string? Country { get; set; }
        public int? Draft_year { get; set; }
        public int? Weight { get; set; }
        public NbaTeam? Team { get; set; }
    }
}
