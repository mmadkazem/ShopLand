namespace ShopLand.Application.Orders.Queries.GetAllOrder.Handler;

public interface IGetAllOrderQueryHandler
{
    Task<IEnumerable<IResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default);
}
