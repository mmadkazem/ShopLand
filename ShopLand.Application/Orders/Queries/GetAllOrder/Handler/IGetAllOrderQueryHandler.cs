namespace ShopLand.Application.Orders.Queries.GetAllOrder.Handler;

public interface IGetAllOrderQueryHandler
{
    Task<IEnumerable<GetOrderQueryResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
