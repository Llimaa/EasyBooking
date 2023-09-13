using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class GetUserRoleQuery : IGetUserRoleQuery
{
    private readonly IUserRoleRepository repository;
    
    public GetUserRoleQuery(IUserRoleRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<GetUserRoleResponse>?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var role = await repository.GetByUserIdAsync(userId, cancellationToken);
        
        if(role is null) 
            return null;

        return role.Select(_ => new GetUserRoleResponse(_.Value));
    }

    public async Task<GetUserRoleResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var role = await repository.GetByIdAsync(id, cancellationToken);
        
        if(role is null) 
            return null;
        
        return new GetUserRoleResponse(role.Value);
    }
}
