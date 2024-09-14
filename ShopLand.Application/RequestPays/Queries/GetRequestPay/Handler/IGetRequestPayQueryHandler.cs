namespace ShopLand.Application.RequestPays.Queries.GetRequestPay.Handler;

public interface IGetRequestPayQueryHandler
{
    Task<IResponse> HandelAsync(GetRequestPayQueryRequest request, CancellationToken token = default);
}
