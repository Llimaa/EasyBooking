namespace EasyBooking.Appplication;

public interface IGetCategoryQuery 
{
    Task<GetCategoryResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<GetCategoryResponse>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken); 
}
