using EasyBooking.Appplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/roles/")]
[ApiVersion("1")]
public class RoleController : ControllerBase
{
    private readonly ICreateUserRole userRole;
    private readonly IGetUserRoleQuery userRoleQuery;

    public RoleController(ICreateUserRole userRole, IGetUserRoleQuery userRoleQuery)
    {
        this.userRole = userRole;
        this.userRoleQuery = userRoleQuery;
    }

    [HttpPost("roles")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> CreateRole([FromBody] CreateUserRoleRequest request, CancellationToken cancellationToken) 
    {
        var result = await userRole.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result?.Id }, result);
    }

    [HttpGet("users/{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetRolesByUserId(Guid id, CancellationToken cancellationToken) 
    {
        var result = await userRoleQuery.GetByUserIdAsync(id, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken) 
    {
        var result = await userRoleQuery.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }
}
