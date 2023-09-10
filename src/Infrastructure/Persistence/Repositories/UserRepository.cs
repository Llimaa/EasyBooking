using EasyBooking.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly EasyBookingDbContext context;

    public UserRepository(EasyBookingDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistThisUserAsync(string email, string document, CancellationToken cancellationToken) =>
        await context.Users.AnyAsync(_ => _.Email == email || _.Document == document, cancellationToken);

    public async Task<User?> FindByEmailAndPasswordAsync(string email, string passwordHasg, CancellationToken cancellationToken) =>
        await context.Users
            .Include(_ => _.Roles)
            .FirstOrDefaultAsync(_ => _.Email == email && _.Password == passwordHasg, cancellationToken: cancellationToken);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken) =>
        await context.Users
            .Include(_ => _.Roles)
            .FirstOrDefaultAsync(_ => _.Email == email, cancellationToken);

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken) => 
        await context.Users
            .Include(_ => _.Roles)
            .FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
}