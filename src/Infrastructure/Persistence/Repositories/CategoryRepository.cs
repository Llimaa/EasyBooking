using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public class CategoryRepository : ICategoryRepository
{
    private readonly EasyBookingDbContext context;

    public CategoryRepository(EasyBookingDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(Category category, CancellationToken cancellationToken)
    {
        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistThisCategoryAsync(string name, CancellationToken cancellationToken) =>
        await context.Categories.AnyAsync(_ => _.Name == name, cancellationToken);

    public async Task<IEnumerable<Category>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.Categories.Where(_ => _.EstablishmentId == id).ToListAsync(cancellationToken);

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.Categories.FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
}