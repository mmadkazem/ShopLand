namespace ShopLand.Application.Orders.Queries.GetOrderByUserId.Request;

public readonly record struct GetOrderByUserIdQueryRequest(Guid UserId)
{
    public static implicit operator GetOrderByUserIdQueryRequest(Guid userId)
        => new(userId);
}