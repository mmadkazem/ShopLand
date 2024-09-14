namespace ShopLand.Application.Orders.Queries.Response;

public sealed record GetOrderQueryResponse
(
    Guid UserId, Guid RequestPayId,
    OrderState OrderState, List<OrderDetail> OrderDetails
) : IResponse;

public readonly record struct OrderDetail(Guid ProductId, uint Count, uint Price);

public static class Extension
{
    public static GetOrderQueryResponse AsResponse(this Domain.Orders.Entities.Order order)
        => new
        (
            order.UserId,
            order.RequestPayId,
            order.OrderState,
            order.OrderDetails.Select(o => new OrderDetail(o.ProductId, o.Count, o.Price)).ToList()
        );
}