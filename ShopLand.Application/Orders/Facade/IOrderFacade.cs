namespace ShopLand.Application.Orders.Facade;

public interface IOrderFacade
{
    ICreateOrderCommandHandler CreateOrder { get; }
    IUpdateOrderStateCommandHandler UpdateOrderState { get; }
    IGetOrderByUserIdQueryHandler GetOrderByUser { get; }
    IGetAllOrderQueryHandler GetAllOrder { get; }
}

public class OrderFacade : IOrderFacade
{
    public OrderFacade(ICreateOrderCommandHandler createOrder,
        IUpdateOrderStateCommandHandler updateOrderState,
        IGetOrderByUserIdQueryHandler getOrderByUser,
        IGetAllOrderQueryHandler getAllOrder)
    {
        _createOrder = createOrder;
        _updateOrderState = updateOrderState;
        _getOrderByUser = getOrderByUser;
        _getAllOrder = getAllOrder;
    }

    private readonly ICreateOrderCommandHandler _createOrder;
    public ICreateOrderCommandHandler CreateOrder
        => _createOrder;

    private readonly IUpdateOrderStateCommandHandler _updateOrderState;
    public IUpdateOrderStateCommandHandler UpdateOrderState
        => _updateOrderState;

    private readonly IGetOrderByUserIdQueryHandler _getOrderByUser;
    public IGetOrderByUserIdQueryHandler GetOrderByUser
        => _getOrderByUser;

    private readonly IGetAllOrderQueryHandler _getAllOrder;
    public IGetAllOrderQueryHandler GetAllOrder
        => _getAllOrder;
}