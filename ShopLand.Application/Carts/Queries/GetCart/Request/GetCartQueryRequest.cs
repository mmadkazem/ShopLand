namespace ShopLand.Application.Carts.Queries.GetCart.Request;

public readonly record struct GetCartQueryRequest(Guid UserId)
{
    public static implicit operator GetCartQueryRequest(Guid userId)
        => new(userId);
};