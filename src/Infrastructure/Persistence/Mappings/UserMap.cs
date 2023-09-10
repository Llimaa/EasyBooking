using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Name).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("name").IsRequired();
            builder.Property(e => e.Document).HasMaxLength(11).HasColumnType("varchar(11)").HasColumnName("document").IsRequired();
            builder.Property(e => e.Email).HasMaxLength(20).HasColumnType("varchar(20)").HasColumnName("email").IsRequired();
            builder.Property(e => e.Password).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("password").IsRequired();
            builder.Property(e => e.Active).HasColumnType("bit").HasColumnName("active").IsRequired();
            builder.Ignore(_ => _.Errors);
            builder.Ignore(_ => _.Valid);
    }
}
