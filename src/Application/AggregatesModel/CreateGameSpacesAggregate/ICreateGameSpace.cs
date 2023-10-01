namespace EasyBooking.Appplication;

public interface ICreateGameSpace 
{
    public Task<CreateGameSpaceResponse?> CreateAsync(CreateGameSpaceRequest request, CancellationToken cancellationToken);
}
