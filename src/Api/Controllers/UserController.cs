using EasyBooking.Appplication;
using EasyBooking.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/users/")]
[ApiVersion("1")]
public class UserController : ControllerBase
{
    private readonly ICreateUser createUser;
    private readonly IGetUserQuery userQuery;
    private readonly IErrorBagService errorBag;

    public UserController(ICreateUser createUser, IGetUserQuery userQuery, IErrorBagService errorBag)
    {
        this.createUser = createUser;
        this.userQuery = userQuery;
        this.errorBag = errorBag;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] CreateUserRequest request, CancellationToken cancellationToken) 
    {
        var result = await createUser.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
    {
        var result = await userQuery.GetByIdAsync(id, cancellationToken);

        if(result is null)
            return NotFound();
        
        return Ok(result);
    }

    [HttpGet("{email}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetByEmail(string email, CancellationToken cancellationToken) 
    {
        var result = await userQuery.GetByEmailAsync(email, cancellationToken);

        if(result is null)
            return NotFound();
        
        return Ok(result);
    }
}
