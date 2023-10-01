using EasyBooking.Domain;
using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class LoginUser : ILoginUser
{
    private readonly IAuthService authService;
    private readonly IUserRepository userRepository;

    public LoginUser(IAuthService authService, IUserRepository userRepository)
    {
        this.authService = authService;
        this.userRepository = userRepository;
    }

    public async Task<LoginUserResponse?> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var passwordHash = authService.ComputeSha256Hash(request.Password);

        var user = await userRepository.FindByEmailAndPasswordAsync(request.Email, passwordHash, cancellationToken);

        if(user is null)
            return null;
            
        var token = authService.GenerateJwtToken(user.Email, user.Id, user.Roles);
        var loginResponse = new LoginUserResponse(token.Value, token.ExpireAt);
        return loginResponse;
    }
}