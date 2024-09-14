namespace ShopLand.Application.Orders.Event.CreatedOrder;

public interface ICreatedOrderEventHandler
{
    Task HandelAsync(Guid userId, CancellationToken token = default);
}