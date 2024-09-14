namespace ShopLand.Application.RequestPays.Queries.GetRequestPaysUser.Handler;

public interface IGetRequestPaysUserQueryHandler
{
    Task<IEnumerable<GetRequestPayQueryResponse>> HandelAsync(GetRequestPaysUserQueryRequest request, CancellationToken token = default);
}