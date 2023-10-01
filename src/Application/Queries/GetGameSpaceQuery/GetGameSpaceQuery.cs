using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class GetGameSpaceQuery : IGetGameSpaceQuery
{
    private readonly IGameSpaceRepository repository;
    public GetGameSpaceQuery(IGameSpaceRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<GetGameSpaceResponse>?> GetByEstablishmentIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var categories = await repository.GetByEstablishmentIdAsync(id, cancellationToken);
        
        if(categories is null) 
            return default;

        return categories.Select(_ => new GetGameSpaceResponse(_.Id, _.Name, _.Status, _.EstablishmentId));
    }

    public async Task<GetGameSpaceResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var GameSpace = await repository.GetByIdAsync(id, cancellationToken);
        
        if(GameSpace is null) 
            return default;

        return new GetGameSpaceResponse(GameSpace.Id, GameSpace.Name, GameSpace.Status, GameSpace.EstablishmentId);
    }
}
