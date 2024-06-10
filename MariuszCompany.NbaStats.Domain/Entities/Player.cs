using MariuszCompany.NbaStats.Domain.Common;

namespace MariuszCompany.NbaStats.Domain.Entities
{
    public class Player : AuditableBaseEntity
    {
        public int IntegrationId { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Position { get; set; }
        public string? Jersey_number { get; set; }
        public string? Country { get; set; }
        public int? Draft_year { get; set; }
        public int? Weight { get; set; }
        public int? TeamIntegrationId { get; set; }
        public Guid? TeamId { get; set; }
        public virtual Team? Team { get; set; }
    }
}
