namespace EasyBooking.Domain;

public class BaseEntity 
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
        Errors = new();
    }

    public Guid Id { get; private set; }
    public Dictionary<string, string> Errors { get; set; }
    public bool Valid { get; set; }
}