namespace ShopLand.Application.Orders.Queries.GetAllOrder.Handler;

public class GetAllOrderQueryHandler(IUnitOfWork uow)
    : IGetAllOrderQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetOrderQueryResponse>> HandelAsync(PageNumberRequest request, CancellationToken token = default)
    {
        var orders = await _uow.Orders.GetAll(request, token);
        if (!orders.Any())
        {
            throw new OrderNotFoundException();
        }

        return orders.Select(o => o.AsResponse());
    }
}