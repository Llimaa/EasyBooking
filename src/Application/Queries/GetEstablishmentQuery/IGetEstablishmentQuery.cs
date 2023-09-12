namespace EasyBooking.Appplication;

public interface IGetEstablishmentQuery 
{
    Task<GetEstablishmentResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
