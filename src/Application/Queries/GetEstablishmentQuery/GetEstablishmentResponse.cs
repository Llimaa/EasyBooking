using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public record GetEstablishmentResponse(
    Guid Id,
    string Name,
    string Description,
    string PhoneNumber,
    EstablishmentStatus Status,
    Address Address
);

