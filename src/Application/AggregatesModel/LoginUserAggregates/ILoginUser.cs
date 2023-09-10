namespace EasyBooking.Appplication;

public interface ILoginUser 
{
    Task<LoginUserResponse?> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
}
