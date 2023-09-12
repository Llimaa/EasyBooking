using EasyBooking.Domain;

namespace EasyBooking.Infrastructure;

public interface IEstablishmentRepository 
{
    Task CreateAsync(Establishment establishment, CancellationToken cancellationToken);
    Task<Establishment?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistThisEstablishmentAsync(string name, CancellationToken cancellationToken);
}
