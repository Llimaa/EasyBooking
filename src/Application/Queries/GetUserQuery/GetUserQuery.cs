using EasyBooking.Infrastructure;

namespace EasyBooking.Appplication;

public class GetUserQuery : IGetUserQuery
{
    private readonly IUserRepository repository;
    
    public GetUserQuery(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<GetUserResponse?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await repository.GetByEmailAsync(email, cancellationToken);
        
        if(user is null) 
            return null;
            
        
        return new GetUserResponse(user.Active, user.Name, user.Document, user.Email);
    }

    public async Task<GetUserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(id, cancellationToken);
        
        if(user is null) 
            return null;
            
        
        return new GetUserResponse(user.Active, user.Name, user.Document, user.Email);
    }
}