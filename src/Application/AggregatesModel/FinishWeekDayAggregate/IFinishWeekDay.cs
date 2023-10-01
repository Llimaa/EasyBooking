namespace EasyBooking.Appplication;

public interface IFinishWeekDay 
{
    public Task FinishAsync(Guid id, CancellationToken cancellationToken);
}
