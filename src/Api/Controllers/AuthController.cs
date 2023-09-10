using EasyBooking.Appplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/auth/")]
[ApiVersion("1")]
public class AuthController : ControllerBase
{
    private readonly ILoginUser loginUser;

    public AuthController(ILoginUser loginUser)
    {
        this.loginUser = loginUser;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request, CancellationToken cancellationToken)
    {
        var loginUserViewModel = await loginUser.LoginAsync(request, cancellationToken);

        if (loginUserViewModel is null) return BadRequest();

        return Ok(loginUserViewModel);
    }
}
