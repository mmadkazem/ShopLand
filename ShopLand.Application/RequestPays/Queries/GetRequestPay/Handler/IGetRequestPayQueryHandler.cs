namespace ShopLand.Application.RequestPays.Queries.GetRequestPay.Handler;

public interface IGetRequestPayQueryHandler
{
    Task<GetRequestPayQueryResponse> HandelAsync(GetRequestPayQueryRequest request);
}
