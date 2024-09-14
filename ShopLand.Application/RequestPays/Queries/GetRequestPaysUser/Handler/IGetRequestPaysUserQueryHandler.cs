namespace ShopLand.Application.RequestPays.Queries.GetRequestPaysUser.Handler;

public interface IGetRequestPaysUserQueryHandler
{
    Task<IEnumerable<IResponse>> HandelAsync(GetRequestPaysUserQueryRequest request, CancellationToken token = default);
}