namespace ShopLand.Application.Orders.Queries.GetOrderByUserId.Request;

public record GetOrderByUserIdQueryRequest(Guid UserId)
{
    public static implicit operator GetOrderByUserIdQueryRequest(Guid userId)
        => new(userId);
}