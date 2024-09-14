using ShopLand.Application.RequestPays.Queries.Response;

namespace ShopLand.Api.Controller.RequestPays;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RequestPaysController(IRequestPayFacade requestPayFacade)
    : ControllerBase
{
    private readonly IRequestPayFacade _requestPayFacade = requestPayFacade;

    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [HttpPost]
    public async Task<IActionResult> Post(CancellationToken token = default)
    {
        await _requestPayFacade.CreateRequestPay.HandelAsync(new(User.UserId()), token);
        return Created();
    }

    [ProducesResponseType<GetRequestPayQueryResponse>((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> Get(Guid id,
        CancellationToken token = default)
    {
        var result = await _requestPayFacade.GetRequestPay.HandelAsync(new(id), token);
        return Ok(result);
    }

    [ProducesResponseType<IEnumerable<GetRequestPayQueryResponse>>((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [HttpGet]
    public async Task<IActionResult> GetByUserId(CancellationToken token = default)
    {
        var result = await _requestPayFacade.GetRequestPaysUser.HandelAsync(new(User.UserId()), token);
        return Ok(result);
    }
}