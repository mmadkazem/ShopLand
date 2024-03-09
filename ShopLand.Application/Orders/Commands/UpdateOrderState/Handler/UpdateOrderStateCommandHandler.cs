namespace ShopLand.Application.Orders.Commands.UpdateOrderState.Handler;
public interface IUpdateOrderStateCommandHandler
{
    Task HandelAsync(UpdateOrderStateCommandRequest request);
}

public class UpdateOrderStateCommandHandler(IUnitOfWork uow)
    : IUpdateOrderStateCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateOrderStateCommandRequest request)
    {
        var order = await _uow.Orders.FindAsync(request.OrderId);
        if (order is null)
        {
            throw new RequestPayNotFoundException();
        }

        order.UpdateOrderState(request.OrderState);
        await _uow.SaveAsync();
    }
}