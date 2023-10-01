using EasyBooking.Domain;

namespace EasyBooking.Infrastructure;

public interface IWeekDayRepository 
{
    Task CreateAsync(WeekDay weekDay, CancellationToken cancellationToken);
    Task<IEnumerable<WeekDay>?> GetByGameSpaceIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistThisWeekDayAsync(DateOnly day, CancellationToken cancellationToken);
    Task ChangeStatusAsync(Guid id, WeekDayStatus status, CancellationToken cancellationToken);
}
