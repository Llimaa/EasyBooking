namespace EasyBooking.Appplication;

public interface ICreateUserRole 
{
    Task<CreateUserRoleResponse?> CreateAsync(CreateUserRoleRequest request, CancellationToken cancellationToken);
}