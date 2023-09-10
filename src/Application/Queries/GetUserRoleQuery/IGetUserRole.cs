namespace EasyBooking.Appplication;

public interface IGetUserRoleQuery 
{
    Task<GetUserRoleResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<GetUserRoleResponse>?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken); 
}
