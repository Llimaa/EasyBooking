namespace EasyBooking.Domain;

public class User: BaseEntity
{
    public bool Active { get; private set; } 
    public string Name { get; private set; } = null!;
    public string Document { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Password { get; private set; } = null!;
    public List<UserRole> Roles { get; private set; } = null!;

    public static User Raise(string name, string document, string email, string hashPassword)
    {
        var instance = new User()
        {
            Active = true,
            Name = name,
            Document = document,
            Email = email,
            Password = hashPassword,
        };
        return instance;
    }
}
