using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public record GetWeekDayResponse(
    Guid Id,
    DateOnly Day,
    WeekDayStatus Status
);
