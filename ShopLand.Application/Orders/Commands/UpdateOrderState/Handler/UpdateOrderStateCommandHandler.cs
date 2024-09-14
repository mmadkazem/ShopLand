namespace ShopLand.Application.Orders.Commands.UpdateOrderState.Handler;

public sealed class UpdateOrderStateCommandHandler(IUnitOfWork uow)
    : IUpdateOrderStateCommandHandler
{
    private readonly IUnitOfWork _uow = uow;

    public async Task HandelAsync(UpdateOrderStateCommandRequest request, CancellationToken token = default)
    {
        var order = await _uow.Orders.FindAsync(request.OrderId, token)
            ?? throw new OrderNotFoundException();

        order.UpdateOrderState(request.OrderState);
        await _uow.SaveChangeAsync(token);
    }
}