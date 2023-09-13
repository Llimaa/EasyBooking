namespace EasyBooking.Domain;

public class Category : BaseEntity
{
    public string Name { get; private set; } = null!;
    public CategoryStatus Status { get; private set; }
    public Guid EstablishmentId { get; private set; }

    public static Category Raise (string name, Guid establishmentId) 
    {
        var instance = new Category() 
        {
            Name = name,
            EstablishmentId = establishmentId,
            Status = CategoryStatus.Active
        };

        return instance;
    }
}
