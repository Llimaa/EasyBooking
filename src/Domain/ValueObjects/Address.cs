namespace EasyBooking.Domain;

public record Address(
    string Neighborhood,
    string Street,
    string Number,
    string Zipcode
);