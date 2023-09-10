using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBooking.Infrastructure;

public class UserConfigurations: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("users")
            .HasKey(x => x.Id);

            builder
                .HasMany(s => s.Roles)
                .WithOne()
                .HasForeignKey(u => u.UserId);
    }
}
