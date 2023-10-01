namespace EasyBooking.Domain;

public class GameSpace : BaseEntity
{
    public string Name { get; private set; } = null!;
    public GameSpaceStatus Status { get; private set; }
    public Guid EstablishmentId { get; private set; }
    public IEnumerable<WeekDay> WeekDays { get; private set; } = default!;
    public static GameSpace Raise (string name, Guid establishmentId) 
    {
        var instance = new GameSpace() 
        {
            Name = name,
            EstablishmentId = establishmentId,
            Status = GameSpaceStatus.Active
        };

        return instance;
    }
}
