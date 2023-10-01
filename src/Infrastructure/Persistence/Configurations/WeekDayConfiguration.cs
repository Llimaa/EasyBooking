using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class WeekDayConfiguration : IEntityTypeConfiguration<WeekDay>
{
    public void Configure(EntityTypeBuilder<WeekDay> builder)
    {
        builder
            .ToTable("weekDays")
            .HasKey(_ => _.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.GameSpaceId).HasColumnName("gameSpaceId").IsRequired();
        builder.Property(e => e.Day).HasConversion<DateOnlyConverter>().HasColumnName("day").IsRequired();
        builder.Property(e => e.Status).HasConversion<int>().HasColumnName("status").IsRequired();
        
        builder
            .HasOne<GameSpace>()
            .WithMany(_ => _.WeekDays)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
