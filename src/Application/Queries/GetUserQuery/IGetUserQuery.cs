namespace EasyBooking.Appplication;

public interface IGetUserQuery 
{
    Task<GetUserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<GetUserResponse?> GetByEmailAsync(string email, CancellationToken cancellationToken); 
}
