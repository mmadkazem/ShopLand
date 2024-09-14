namespace ShopLand.Application.Orders.Queries.GetOrderByUserId.Handler;

public interface IGetOrderByUserIdQueryHandler
{
    Task<IEnumerable<GetOrderQueryResponse>> HandelAsync(GetOrderByUserIdQueryRequest request, CancellationToken token = default);
}
