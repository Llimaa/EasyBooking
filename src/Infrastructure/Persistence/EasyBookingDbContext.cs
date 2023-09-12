using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public partial class EasyBookingDbContext: DbContext
{
    public EasyBookingDbContext(DbContextOptions<EasyBookingDbContext> options): base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; }= null!;
    public DbSet<Establishment> Establishments { get; set; }= null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new EstablishmentConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}