namespace EasyBooking.Domain;

public class WeekDay: BaseEntity 
{
    private WeekDay(DateOnly day, WeekDayStatus status, Guid gameSpaceId)
    {
        Day = day;
        Status = status;
        GameSpaceId = gameSpaceId;
    }

    public DateOnly Day { get; private set; }
    public WeekDayStatus Status { get; private set; }
    public Guid GameSpaceId { get; private set; }

    public static WeekDay Raise(DateOnly day, Guid gameSpaceId) 
    {
        var instance = new WeekDay(day, WeekDayStatus.Created, gameSpaceId);
        return instance;
    }
}
