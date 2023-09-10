namespace EasyBooking.Appplication;

public record CreateUserRequest(
    string Name,
    string Document,
    string Email,
    string Password
);