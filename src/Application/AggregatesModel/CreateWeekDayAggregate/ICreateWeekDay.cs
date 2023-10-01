namespace EasyBooking.Appplication;

public interface ICreateWeekDay 
{
    public Task<CreateWeekDayResponse?> CreateAsync(CreateWeekDayRequest request, CancellationToken cancellationToken);
}
