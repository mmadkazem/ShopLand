using Microsoft.AspNetCore.Cors;

namespace ShopLand.Api.Controller.Accounts;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IAccountFacade account)
    : ControllerBase
{
    private readonly IAccountFacade _account = account;

    [HttpPost("api/[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Register
        ([FromBody] RegisterUserCommandRequest request)
    {
        await _account.RegisterUser.HandelAsync(request);
        return Ok();
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login
        ([FromBody] LoginUserQueryRequest request)
    {
        var result = await _account.LoginUser.HandelAsync(request);
        return Ok(result);
    }

    [HttpPost("{UserId:guid}/UserRole")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> AddUserRole
        ([FromBody] AddUserRoleCommandRequest request)
    {
        await _account.AddUserRole.HandelAsync(request);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var result = await _account.GetUser
            .HandelAsync(User.UserId());
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _account.GetUser
        .HandelAsync(id);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> ChangePassword
        ([FromBody] ChangePasswordCommandRequest request)
    {
        await _account.ChangePassword.HandelAsync(request);
        return Ok();
    }

    [HttpDelete("{UserId:guid}/UserRole/{RoleName}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> RemoveUserRole
        ([FromBody] RemoveUserRoleCommandRequest request)
    {
        await _account.RemoveUserRole.HandelAsync(request);
        return Ok();
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginByRefreshToken
        ([FromBody] string refreshToken)
    {
        var newRefreshToken = new JsonWebToken(refreshToken);
        var refreshTokenSerial = newRefreshToken
            .GetClaim(ClaimTypes.SerialNumber).Value;

        var userId = Guid.Parse(newRefreshToken.GetClaim(ClaimTypes.NameIdentifier).Value.ToUserId());

        var result = await _account.LoginUserByRefreshToken
            .HandelAsync(new(userId, refreshTokenSerial));

        return Ok(result);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout
        ([FromBody] UserLogoutCommandRequest request)
    {
        await _account.UserLogout.HandelAsync(request);
        return Ok();
    }
}