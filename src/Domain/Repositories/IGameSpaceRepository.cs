using EasyBooking.Domain;

namespace EasyBooking.Infrastructure;

public interface IGameSpaceRepository 
{
    Task CreateAsync(GameSpace gameSpace, CancellationToken cancellationToken);
    Task<GameSpace?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<GameSpace>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistThisGameSpaceAsync(string name, CancellationToken cancellationToken);
}
