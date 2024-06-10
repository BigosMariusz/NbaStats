using MariuszCompany.NbaStats.Domain.Common;

namespace MariuszCompany.NbaStats.Domain.Entities
{
    public class IntegrationProcess : IdentitableEntity
    {
        public bool Success { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
