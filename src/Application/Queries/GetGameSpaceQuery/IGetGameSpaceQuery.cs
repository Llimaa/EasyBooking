namespace EasyBooking.Appplication;

public interface IGetGameSpaceQuery 
{
    Task<GetGameSpaceResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<GetGameSpaceResponse>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken); 
}
