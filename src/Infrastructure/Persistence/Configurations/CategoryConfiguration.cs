using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .ToTable("categories")
            .HasKey(_ => _.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.Name).HasMaxLength(20).HasColumnType("varchar(20)").HasColumnName("name").IsRequired();
        builder.Property(e => e.EstablishmentId).HasColumnName("establishmentId").IsRequired();
        
        builder
            .HasOne<Establishment>()
            .WithMany(_ => _.Categories)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
