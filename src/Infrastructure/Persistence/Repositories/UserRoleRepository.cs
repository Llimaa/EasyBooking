using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly EasyBookingDbContext context;

    public UserRoleRepository(EasyBookingDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(UserRole userRole, CancellationToken cancellationToken)
    {
        await context.UserRoles.AddAsync(userRole, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistThisUserRoleAsync(Guid userId, string value, CancellationToken cancellationToken) =>
        await context.UserRoles.AnyAsync(_ => _.UserId == userId && _.Value == value, cancellationToken);

    public async Task<UserRole?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.UserRoles.FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);

    public async Task<IEnumerable<UserRole>?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken) => 
        await context.UserRoles.Where(_ => _.UserId == userId).ToListAsync(cancellationToken);
}