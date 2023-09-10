using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class UserRoleMap : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("userRoles");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Value).HasMaxLength(20).HasColumnType("varchar(100)").HasColumnName("value").IsRequired();
            builder.Property(e => e.UserId).HasColumnName("userId").IsRequired();
            builder.Ignore(_ => _.Errors);
            builder.Ignore(_ => _.Valid);
    }
}