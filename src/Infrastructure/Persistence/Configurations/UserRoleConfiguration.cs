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

        builder
            .HasOne<User>()
            .WithMany(u => u.Roles)
            .HasForeignKey( _ => _.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
