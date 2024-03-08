namespace ShopLand.Application.RequestPays.Queries.GetRequestPaysUser.Handler;

public interface IGetRequestPaysUserQueryHandler
{
    Task<IEnumerable<GetRequestPayQueryResponse>> HandelAsync
        (GetRequestPaysUserQueryRequest request);
}

public class GetRequestPaysUserQueryHandler(IUnitOfWork uow)
    : IGetRequestPaysUserQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetRequestPayQueryResponse>> HandelAsync
        (GetRequestPaysUserQueryRequest request)
    {
        var requestPays = await _uow.RequestPays
            .FindAsyncByUserId(request.UserId);

        if (requestPays.Count() == 0)
        {
            throw new RequestPayNotFoundException();
        }

        return requestPays.Select(r => r.AsResponse()).ToList();
    }
}