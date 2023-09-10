using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;
public partial class EasyBookingDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserRoleMap());
    }
}


