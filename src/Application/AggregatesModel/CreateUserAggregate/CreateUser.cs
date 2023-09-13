using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;

namespace EasyBooking.Appplication;

public class CreateUser : ICreateUser
{
    private readonly IAuthService authService;
    private readonly IUserRepository userRepository;
    private readonly ICreateUserRole createUserRole;
    private readonly IValidator<CreateUserRequest> validator;
    private readonly IErrorBagService errorBagService;
    

    public CreateUser(IAuthService authService, IUserRepository userRepository, ICreateUserRole createUserRole, IValidator<CreateUserRequest> validator, IErrorBagService errorBagService)
    {
        this.authService = authService;
        this.userRepository = userRepository;
        this.validator = validator;
        this.createUserRole = createUserRole;
        this.errorBagService = errorBagService;
    }

    public async Task<CreateUserResponse?> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var (errors, valid) = request.Validate(validator);

        if(!valid){
            errorBagService.HandlerError(errors);
            return default;
        }

        var hashPassword = authService.ComputeSha256Hash(request.Password);
        var user = User.Raise(request.Name, request.Document, request.Email, hashPassword);

        var exist = await userRepository.ExistThisUserAsync(request.Email, request.Document, cancellationToken);

        if(exist) 
        {
            errorBagService.HandlerError("User Exist", "Já existe um usuário cadastrado com esse email ou documento");
            return default;
        }

        await userRepository.CreateAsync(user, cancellationToken);
        await CreateDefaultUserRole(user.Id, cancellationToken);

        var response = new CreateUserResponse(user.Id);        
        return response;
    }

    private async Task CreateDefaultUserRole(Guid userId, CancellationToken cancellationToken)
    {
        var userRole = new CreateUserRoleRequest("user", userId);
        await createUserRole.CreateAsync(userRole, cancellationToken);
    }
}
