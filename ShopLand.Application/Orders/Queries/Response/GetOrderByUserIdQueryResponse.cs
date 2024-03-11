namespace ShopLand.Application.Orders.Queries.Response;

public record GetOrderQueryResponse(Guid UserId, Guid RequestPayId,
    OrderState OrderState, List<OrderDetailResponse> OrderDetails);
public record OrderDetailResponse(Guid ProductId, uint Count, uint Price);

public static class Extension
{
    public static GetOrderQueryResponse AsResponse
        (this Domain.Orders.Entities.Order order)
    {
        var orderDetailResponse = order.OrderDetails
            .Select(o => new OrderDetailResponse(o.ProductId, o.Count, o.Price))
            .ToList();
        return new(order.UserId, order.RequestPayId, order.OrderState, orderDetailResponse);
    }
}