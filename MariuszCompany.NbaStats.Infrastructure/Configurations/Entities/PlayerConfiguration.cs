using MariuszCompany.NbaStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MariuszCompany.NbaStats.Infrastructure.Configurations.Entities;
internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players");
        builder.HasKey(x => x.Id);

        builder.HasOne(m => m.Team)
            .WithMany(t => t.Players)
            .HasForeignKey(m => m.TeamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Country);
        builder.HasIndex(x => x.Draft_year);

        builder.Property(x => x.First_name).HasMaxLength(50);
        builder.Property(x => x.Last_name).HasMaxLength(50);
        builder.Property(x => x.Position).HasMaxLength(20);
        builder.Property(x => x.Jersey_number).HasMaxLength(20);
        builder.Property(x => x.Country).HasMaxLength(50);
    }
}
