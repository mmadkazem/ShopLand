namespace ShopLand.Api.Controller.Accounts;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IAccountFacade account)
    : ControllerBase
{
    private readonly IAccountFacade _account = account;

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register
        ([FromBody] RegisterUserCommandRequest request)
    {
        await _account.RegisterUser.HandelAsync(request);
        return Ok();
    }

    [HttpPost("Login")]
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

    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var result = await _account.GetCurrentUser
        .HandelAsync(User.UserId());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var result = await _account.GetCurrentUser
        .HandelAsync(id);
        return Ok(result);
    }

    [HttpPut("ChangePassword")]
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

    [HttpDelete]
    [Authorize(CustomRoles.Admin)]
    public async Task<IActionResult> RemoveUser()
    {
        await Task.CompletedTask;
        return Ok();
    }
}