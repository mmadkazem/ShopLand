namespace ShopLand.Domain.Orders.ValueObject;

public record OrderDetail
{
    public Guid ProductId { get; private set; }
    public OrderId OrderId { get; private set; }
    public uint Count { get; private set; }
    public uint Price { get; private set; }

    public OrderDetail(Guid productId, OrderId orderId, uint count, uint price)
    {
        ProductId = productId;
        OrderId = orderId;
        Count = count;
        Price = price;
    }
}