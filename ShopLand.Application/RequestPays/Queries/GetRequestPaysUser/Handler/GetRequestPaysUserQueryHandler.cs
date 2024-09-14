namespace ShopLand.Application.RequestPays.Queries.GetRequestPaysUser.Handler;

public class GetRequestPaysUserQueryHandler(IUnitOfWork uow)
    : IGetRequestPaysUserQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetRequestPayQueryResponse>> HandelAsync(GetRequestPaysUserQueryRequest request, CancellationToken token = default)
    {
        var requestPays = await _uow.RequestPays.FindAsyncByUserId(request.UserId, token);
        if (!requestPays.Any())
        {
            throw new RequestPayNotFoundException();
        }

        return requestPays.Select(r => r.AsResponse()).ToList();
    }
}