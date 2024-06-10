using MariuszCompany.NbaStats.Domain.Common;
using MariuszCompany.NbaStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MariuszCompany.NbaStats.Infrastructure.DbContexts
{
    public class NbaDbContext : DbContext
    {
        public NbaDbContext(DbContextOptions<NbaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<IntegrationProcess> IntegrationProcesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NbaDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreatedUtc = DateTime.UtcNow;
                        entry.Entity.DateModifiedUtc = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModifiedUtc = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
