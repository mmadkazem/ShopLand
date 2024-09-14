namespace ShopLand.Api.Controller.Accounts;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IAccountFacade account)
    : ControllerBase
{
    private readonly IAccountFacade _account = account;

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<Results<Ok, BadRequest>> Register
        ([FromBody] RegisterUserCommandRequest request)
    {
        await _account.RegisterUser.HandelAsync(request);
        return TypedResults.Ok();
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<Results<Ok<JwtTokensDataResponse>, BadRequest, NotFound>> Login
        ([FromBody] LoginUserQueryRequest request)
    {
        var result = await _account.LoginUser.HandelAsync(request);
        return TypedResults.Ok(result);
    }

    [HttpPost("{UserId:guid}/UserRole")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> AddUserRole(Guid userId, string roleName,
        CancellationToken token = default)
    {
        await _account.AddUserRole.HandelAsync(new AddUserRoleCommandRequest(userId, roleName), token);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetCurrentUser(CancellationToken token = default)
    {
        var result = await _account.GetUser
            .HandelAsync(User.UserId(), token);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserById(Guid id,
        CancellationToken token = default)
    {
        var result = await _account.GetUser
        .HandelAsync(id, token);
        return Ok(result);
    }

    [HttpPut("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommandRequest request,
        CancellationToken token = default)
    {
        await _account.ChangePassword.HandelAsync(request, token);
        return Ok();
    }

    [HttpDelete("{UserId:guid}/UserRole/{RoleId:guid}")]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> RemoveUserRole(Guid userId, Guid roleId,
        CancellationToken token = default)
    {
        await _account.RemoveUserRole.HandelAsync(new RemoveUserRoleCommandRequest(userId, roleId), token);
        return Ok();
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "RefreshScheme")]
    public async Task<IActionResult> LoginByRefreshToken(CancellationToken token = default)
    {
        var result = await _account.LoginUserByRefreshToken
            .HandelAsync(new(User.UserId(), User.RefreshTokenSerial()), token);

        return Ok(result);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Logout(CancellationToken token = default)
    {
        await _account.UserLogout.HandelAsync(User.UserId(), token);
        return Ok();
    }
}