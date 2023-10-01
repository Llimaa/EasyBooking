using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public record GetGameSpaceResponse(
    Guid Id,
    string Name,
    GameSpaceStatus Status,
    Guid EstablishmentId
);
