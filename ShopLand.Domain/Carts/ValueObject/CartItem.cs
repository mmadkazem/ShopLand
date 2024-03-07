namespace ShopLand.Domain.Carts.ValueObject;

public record CartItem
{
    public Count Count { get; private set; }
    public Guid ProductId { get; private set; }
    public CartId CartId { get; private set; }

    public CartItem(Count count,
        Guid productId, CartId cartId)
    {
        Count = count;
        ProductId = productId;
        CartId = cartId;
    }

}