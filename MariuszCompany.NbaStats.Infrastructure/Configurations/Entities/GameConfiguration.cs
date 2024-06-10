using MariuszCompany.NbaStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace MariuszCompany.NbaStats.Infrastructure.Configurations.Entities;
internal class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");
        builder.HasKey(x => x.Id);

        builder.HasOne(m => m.HomeTeam)
            .WithMany(t => t.HomeGames)
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.VisitorTeam)
            .WithMany(t => t.VisitorGames)
            .HasForeignKey(m => m.VisitorTeamId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.Status).HasMaxLength(50);
    }
}