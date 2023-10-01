namespace EasyBooking.Appplication;

public interface ICancellWeekDay 
{
    public Task CancellAsync(Guid id, CancellationToken cancellationToken);
}
