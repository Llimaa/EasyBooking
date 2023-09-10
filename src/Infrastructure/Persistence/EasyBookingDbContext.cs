using System.Reflection;
using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public partial class EasyBookingDbContext: DbContext
{
    public EasyBookingDbContext(DbContextOptions<EasyBookingDbContext> options): base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserRole> UserRoles { get; set; }= null!;
}