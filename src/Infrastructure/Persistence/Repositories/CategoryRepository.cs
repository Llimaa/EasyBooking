using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public class GameSpacesRepository : IGameSpaceRepository
{
    private readonly EasyBookingDbContext context;

    public GameSpacesRepository(EasyBookingDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(GameSpace gameSpaces, CancellationToken cancellationToken)
    {
        await context.GameSpaces.AddAsync(gameSpaces, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> ExistThisGameSpaceAsync(string name, CancellationToken cancellationToken) =>
        await context.GameSpaces.AnyAsync(_ => _.Name == name, cancellationToken);

    public async Task<IEnumerable<GameSpace>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.GameSpaces.Where(_ => _.EstablishmentId == id).ToListAsync(cancellationToken);

    public async Task<GameSpace?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.GameSpaces.FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
}