using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class EstablishmentConfigurations: IEntityTypeConfiguration<Establishment>
{
    public void Configure(EntityTypeBuilder<Establishment> builder)
    {
        builder
            .ToTable("establishments")
            .HasKey(x => x.Id);
        
        builder.Property(e => e.PhoneNumber).HasMaxLength(15).HasColumnType("varchar(15)").HasColumnName("phoneNumber").IsRequired();
        builder.Property(e => e.Status).HasConversion<int>().HasColumnName("status").IsRequired();
        builder.Property(e => e.Name).HasMaxLength(20).HasColumnType("varchar(20)").HasColumnName("name").IsRequired();
        builder.Property(e => e.Description).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("description").IsRequired();

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Neighborhood)
            .HasColumnName("addressNeighborhood")
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired(true);

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Street)
            .HasColumnName("addressStreet")
            .HasMaxLength(50)
            .HasColumnType("varchar(50)")
            .IsRequired(true);

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Number)
            .HasColumnName("addressNumbers")
            .HasMaxLength(10)
            .HasColumnType("varchar(10)")
            .IsRequired(true);
        
        builder.OwnsOne(x => x.Address)
            .Property(x => x.Zipcode)
            .HasColumnName("addressZipcode")
            .HasMaxLength(15)
            .HasColumnType("varchar(15)")
            .IsRequired(true);
        
        builder.Ignore(_ => _.Errors);
        builder.Ignore(_ => _.Valid);
    }
}
