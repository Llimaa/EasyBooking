namespace EasyBooking.Appplication;

public interface ICreateUser 
{
    Task<CreateUserResponse?> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
}
