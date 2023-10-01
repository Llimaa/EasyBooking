using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class GameSpaceConfiguration : IEntityTypeConfiguration<GameSpace>
{
    public void Configure(EntityTypeBuilder<GameSpace> builder)
    {
        builder
            .ToTable("categories")
            .HasKey(_ => _.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.Name).HasMaxLength(20).HasColumnType("varchar(20)").HasColumnName("name").IsRequired();
        builder.Property(e => e.EstablishmentId).HasColumnName("establishmentId").IsRequired();
        
        builder
            .HasOne<Establishment>()
            .WithMany(_ => _.GameSpaces)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
