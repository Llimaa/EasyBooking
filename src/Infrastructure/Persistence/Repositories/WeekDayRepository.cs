using EasyBooking.Domain;
using Microsoft.EntityFrameworkCore;

namespace EasyBooking.Infrastructure;

public class WeekDayRepository : IWeekDayRepository
{
    private readonly EasyBookingDbContext context;

    public WeekDayRepository(EasyBookingDbContext context)
    {
        this.context = context;
    }

    public async Task ChangeStatusAsync(Guid id, WeekDayStatus status, CancellationToken cancellationToken) =>
        await context.WeekDays
            .Where(_ => _.Id == id)
            .ExecuteUpdateAsync(_ => _.SetProperty(e => e.Status, status), cancellationToken);

    public async Task CreateAsync(WeekDay weekDay, CancellationToken cancellationToken)
    {
        await context.WeekDays.AddAsync(weekDay, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }


    public async Task<bool> ExistThisWeekDayAsync(DateOnly day, CancellationToken cancellationToken) =>
        await context.WeekDays.AnyAsync(_ => _.Day == day, cancellationToken);

    public async Task<IEnumerable<WeekDay>?> GetByGameSpaceIdAsync(Guid id, CancellationToken cancellationToken) =>
        await context.WeekDays.Where(_ => _.GameSpaceId == id).ToListAsync(cancellationToken);
}
