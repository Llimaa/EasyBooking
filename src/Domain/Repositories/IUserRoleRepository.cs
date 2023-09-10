using EasyBooking.Domain;

namespace EasyBooking.Infrastructure;

public interface IUserRoleRepository 
{
    Task CreateAsync(UserRole userRole, CancellationToken cancellationToken);
    Task<UserRole?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<UserRole>?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<bool> ExistThisUserRoleAsync(Guid userId, string value, CancellationToken cancellationToken);
}
