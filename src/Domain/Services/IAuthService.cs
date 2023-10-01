namespace EasyBooking.Domain;

public interface IAuthService 
{
    Token GenerateJwtToken(string email, Guid id, List<UserRole> roles);
    string ComputeSha256Hash(string password);
}
