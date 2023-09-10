using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public record GetUserResponse(
    bool Active,
    string Name,
    string Document,
    string Email
);
