namespace ShopLand.Api.Controller.Accounts;



[ApiController]
[Route("api/[controller]")]
[Authorize(CustomRoles.Admin)]
public class RolesController(IAccountFacade account)
    : ControllerBase
{
    private readonly IAccountFacade _account = account;

    [HttpGet("Page/{page:int}")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType<IEnumerable<GetAllRoleQueryResponse>>((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllRole(int page,
        CancellationToken token = default)
    {
        var roles = await _account.GetAllRole.HandelAsync(page, token);
        return Ok(roles);
    }
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateRole(CreateRoleCommandRequest request,
        CancellationToken token = default)
    {
        await _account.CreateRole.HandelAsync(request, token);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> RemoveRole(RemoveRoleCommandRequest request,
        CancellationToken token = default)
    {
        await _account.RemoveRole.HandelAsync(request, token);
        return Ok();
    }
}