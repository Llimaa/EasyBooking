using EasyBooking.Domain;

namespace EasyBooking.Infrastructure;

public interface IUserRepository 
{
    Task CreateAsync(User user, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User?> FindByEmailAndPasswordAsync(string email, string passwordHasg, CancellationToken cancellationToken);
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistThisUserAsync(string email, string document, CancellationToken cancellationToken);
}