namespace MariuszCompany.NbaStats.Domain.Common
{
    public abstract class IdentitableEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
