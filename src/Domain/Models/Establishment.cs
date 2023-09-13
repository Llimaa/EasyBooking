namespace EasyBooking.Domain;

public class Establishment : BaseEntity
{
    public string PhoneNumber { get; private set; }  = null!;
    public EstablishmentStatus Status { get; private set; } = default!;
    public string Name { get; private set; }  = null!;
    public string Description { get; private set; }  = null!;
    public Address Address { get; private set; }  = null!;

    public List<Category> Categories { get; private set; } = null!;

    public static Establishment Raise(string phoneNumber, string name, string description, Address address)
    {
        var instance = new Establishment() 
        {
            PhoneNumber = phoneNumber,
            Status = EstablishmentStatus.Active,
            Name = name,
            Description = description,
            Address = address
        };
        return instance;
    }
}
