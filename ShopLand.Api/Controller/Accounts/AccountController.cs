namespace ShopLand.Api.Controller.Accounts;


[ApiController]
[Route("api/[controller]/[action]")]
public sealed class AccountController(IAccountFacade account)
    : ControllerBase
{
    private readonly IAccountFacade _account = account;

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Register(RegisterUserCommandRequest request,
        CancellationToken token = default)
    {
        await _account.RegisterUser.HandelAsync(request, token);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType<JwtTokensDataResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Login(LoginUserQueryRequest request,
        CancellationToken token = default)
    {
        var result = await _account.LoginUser.HandelAsync(request, token);
        return Ok(result);
    }

    [Authorize(CustomRoles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [HttpPost("api/[controller]/{UserId:guid}/UserRole")]

    public async Task<IActionResult> AddUserRole(Guid userId, string roleName,
        CancellationToken token = default)
    {
        await _account.AddUserRole.HandelAsync(new(userId, roleName), token);
        return Ok();
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType<GetUserQueryResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCurrentUser(CancellationToken token = default)
    {
        var result = await _account.GetUser.HandelAsync(User.UserId(), token);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(CustomRoles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<GetUserQueryResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserById(Guid id,
        CancellationToken token = default)
    {
        var result = await _account.GetUser.HandelAsync(id, token);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]

    public async Task<IActionResult> ChangePassword(ChangePasswordCommandRequest request,
        CancellationToken token = default)
    {
        await _account.ChangePassword.HandelAsync(request, token);
        return Ok();
    }

    [Authorize(CustomRoles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [HttpDelete("api/[controller]/{UserId:guid}/UserRole/{RoleId:guid}")]
    public async Task<IActionResult> RemoveUserRole(Guid userId, Guid roleId,
        CancellationToken token = default)
    {
        await _account.RemoveUserRole.HandelAsync(new(userId, roleId), token);
        return Ok();
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "RefreshScheme")]
    [ProducesResponseType<JwtTokensDataResponse>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> LoginByRefreshToken(CancellationToken token = default)
    {
        var result = await _account.LoginUserByRefreshToken.HandelAsync
        (
            new(User.UserId(), User.RefreshTokenSerial()), token
        );
        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Logout(CancellationToken token = default)
    {
        await _account.UserLogout.HandelAsync(User.UserId(), token);
        return Ok();
    }
}