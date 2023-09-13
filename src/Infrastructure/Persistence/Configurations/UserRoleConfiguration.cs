using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder
            .ToTable("userRoles")
            .HasKey(_ => _.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.Value).HasMaxLength(20).HasColumnType("varchar(100)").HasColumnName("value").IsRequired();
        builder.Property(e => e.UserId).HasColumnName("userId").IsRequired();
        
        builder
            .HasOne<User>()
            .WithMany(u => u.Roles)
            .HasForeignKey( _ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
