namespace ShopLand.Application.Orders.Queries.GetOrderByUserId.Handler;

public sealed class GetOrderByUserIdQueryHandler(IUnitOfWork uow)
    : IGetOrderByUserIdQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetOrderQueryResponse>> HandelAsync(GetOrderByUserIdQueryRequest request, CancellationToken token = default)
    {
        var orders = await _uow.Orders.FindAsyncByUserId(request.UserId, token);
        if (!orders.Any())
        {
            throw new OrderNotFoundException();
        }

        return orders.Select(o => o.AsResponse()).ToList();
    }
}