using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public class EstablishmentRepository : IEstablishmentRepository
{
    private readonly EasyBookingDbContext context;

    public EstablishmentRepository(EasyBookingDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(Establishment establishment, CancellationToken cancellationToken)
    {
        await context.Establishments.AddAsync(establishment, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistThisEstablishmentAsync(string name, CancellationToken cancellationToken) =>
        await context.Establishments.AnyAsync(_ => _.Name == name, cancellationToken);

    public async Task<Establishment?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.Establishments.FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
}