namespace ShopLand.Api.Controller.Accounts;
[ApiController]
[Route("api/[controller]")]
[Authorize(CustomRoles.Admin)]
public class RolesController(IAccountFacade account)
    : ControllerBase
{
    private readonly IAccountFacade _account = account;

    [HttpGet]
    public async Task<IActionResult> GetAllRole
        ([FromHeader] PageNumberRequest request)
    {
        var roles = await _account.GetAllRole.HandelAsync(request);
        return Ok(roles);
    }
    [HttpPost]
    public async Task<IActionResult> CreateRole
        ([FromBody] CreateRoleCommandRequest request)
    {
        await _account.CreateRole.HandelAsync(request);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveRole
        ([FromBody] RemoveRoleCommandRequest request)
    {
        await _account.RemoveRole.HandelAsync(request);
        return Ok();
    }
}