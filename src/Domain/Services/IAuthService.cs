namespace EasyBooking.Domain;

public interface IAuthService 
{
    Token GenerateJwtToken(string email, List<UserRole> roles);
    string ComputeSha256Hash(string password);
}
