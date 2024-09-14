namespace ShopLand.Domain.Carts.ValueObject;

public record CartItem
{
    public Count Count { get; private set; }
    public CartId CartId { get; private set; }
    public Guid ProductId { get; private set; }
    public uint TotalPrice { get; private set; }
    public uint ProductPrice { get; private set; }

    public CartItem(Count count, Guid productId, CartId cartId, uint productPrice)
    {
        Count = count;
        ProductId = productId;
        CartId = cartId;
        ProductPrice = productPrice;
        TotalPrice = productPrice * count;
    }

    public void AddCount(Count count)
    {
        Count += count;
    }

}