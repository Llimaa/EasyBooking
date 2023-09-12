namespace EasyBooking.Appplication;

public interface ICreateEstablishment 
{
    Task<CreateEstablishmentResponse?> CreateAsync(CreateEstablishmentRequest request, CancellationToken cancellationToken);
}
