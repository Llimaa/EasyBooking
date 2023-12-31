using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateUserRole : ICreateUserRole
{
    private readonly IUserRoleRepository repository;
    private readonly IValidator<CreateUserRoleRequest> validator;
    private readonly IErrorBagService errorBagService;

    public CreateUserRole(IUserRoleRepository repository, IValidator<CreateUserRoleRequest> validator, IErrorBagService errorBagService)
    {
        this.repository = repository;
        this.validator = validator;
        this.errorBagService = errorBagService;
    }

    public async Task<CreateUserRoleResponse?> CreateAsync(CreateUserRoleRequest request, CancellationToken cancellationToken)
    {
        var userRole = UserRole.Raise(request.Value, request.UserId);

        var (errors, valid) = request.Validate(validator);

        if(!valid){
            errorBagService.HandlerError(errors);
            return default;
        }

        var exist = await repository.ExistThisUserRoleAsync(request.UserId, request.Value, cancellationToken);

        if(exist) 
        {
            errorBagService.HandlerError("Role Exist", "Esse usuário já possui essa permissão");
            return default;
        }

        await repository.CreateAsync(userRole, cancellationToken);
        
        var response = new CreateUserRoleResponse(userRole.Id);
        return response;
    }
}
