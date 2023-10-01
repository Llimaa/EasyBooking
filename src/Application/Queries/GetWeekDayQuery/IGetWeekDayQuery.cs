namespace EasyBooking.Appplication;

public interface IGetWeekDayQuery 
{
    Task<IEnumerable<GetWeekDayResponse>?> GetByCategoryIdIdAsync(Guid id, CancellationToken cancellationToken);
}
