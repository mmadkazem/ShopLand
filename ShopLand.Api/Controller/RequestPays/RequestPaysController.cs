namespace ShopLand.Api.Controller.RequestPays;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RequestPaysController(IRequestPayFacade requestPayFacade)
    : ControllerBase
{
    private readonly IRequestPayFacade _requestPayFacade = requestPayFacade;

    [HttpPost]
    public async Task<IActionResult> Post
        ([FromBody] CreateRequestPayCommandRequest request)
    {
        await _requestPayFacade.CreateRequestPay.HandelAsync(request);
        return Created();
    }

    [HttpGet("{RequestPayId:guid}")]
    public async Task<IActionResult> Get
        ([FromHeader] GetRequestPayQueryRequest request)
    {
        var result = await _requestPayFacade.GetRequestPay.HandelAsync(request);
        return Ok(result);
    }

    [HttpGet("User/{UserId:guid}")]
    public async Task<IActionResult> GetByUserId
        ([FromHeader] GetRequestPaysUserQueryRequest request)
    {
        var result = await _requestPayFacade.GetRequestPaysUser
            .HandelAsync(request);
        return Ok(result);
    }
}