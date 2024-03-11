namespace ShopLand.Application.Orders.Queries.GetAllOrder.Handler;

public interface IGetAllOrderQueryHandler
{
    Task<IEnumerable<GetOrderQueryResponse>> HandelAsync
        (PageNumberRequest request);
}

public class GetAllOrderQueryHandler(IUnitOfWork uow)
    : IGetAllOrderQueryHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<GetOrderQueryResponse>> HandelAsync
        (PageNumberRequest request)
    {
        var orders = await _uow.Orders.GetAll(request);
        if (orders.Count() == 0)
        {
            throw new OrderNotFoundException();
        }

        return orders.Select(o => o.AsResponse());
    }
}