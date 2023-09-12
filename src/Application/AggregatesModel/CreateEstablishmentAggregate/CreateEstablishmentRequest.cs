using EasyBooking.Domain;

namespace EasyBooking.Appplication;

public record CreateEstablishmentRequest(
    string PhoneNumber,
    string Name,
    string Description,
    string Neighborhood,
    string Street,
    string Number,
    string Zipcode
);
