using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public record GetCategoryResponse(
    Guid Id,
    string Name,
    CategoryStatus Status,
    Guid EstablishmentId
);
