using MariuszCompany.NbaStats.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace MariuszCompany.NbaStats.Infrastructure.Configurations.Entities;
internal class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("Teams");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Conference).HasMaxLength(50);
        builder.Property(x => x.Division).HasMaxLength(50);
        builder.Property(x => x.City).HasMaxLength(50);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Full_name).HasMaxLength(50);
        builder.Property(x => x.Abbreviation).HasMaxLength(50);
    }
}
