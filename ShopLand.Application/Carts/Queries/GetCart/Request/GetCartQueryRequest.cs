namespace ShopLand.Application.Carts.Queries.GetCart.Request;

public record GetCartQueryRequest(Guid userId)
{
    public static implicit operator GetCartQueryRequest(Guid userId)
        => new(userId);
};