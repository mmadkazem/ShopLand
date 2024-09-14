namespace ShopLand.Application.Orders.Queries.GetOrderByUserId.Handler;

public interface IGetOrderByUserIdQueryHandler
{
    Task<IEnumerable<IResponse>> HandelAsync(GetOrderByUserIdQueryRequest request, CancellationToken token = default);
}
