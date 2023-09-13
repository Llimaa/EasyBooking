namespace EasyBooking.Domain;

public class UserRole : BaseEntity
{
    public string Value { get; private set; } = null!;
    public Guid UserId { get; private set; }

    public static UserRole Raise (string value, Guid userId) 
    {
        var instance = new UserRole() 
        {
            Value = value,
            UserId = userId
        };

        return instance;
    }
}
