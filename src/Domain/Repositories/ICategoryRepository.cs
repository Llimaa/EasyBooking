using EasyBooking.Domain;

namespace EasyBooking.Infrastructure;

public interface ICategoryRepository 
{
    Task CreateAsync(Category category, CancellationToken cancellationToken);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Category>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistThisCategoryAsync(string name, CancellationToken cancellationToken);
}
