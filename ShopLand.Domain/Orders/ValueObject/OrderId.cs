namespace ShopLand.Domain.Orders.ValueObject;

public record OrderId : ID
{
    public Guid Value { get; }

    public OrderId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new OrderIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(OrderId id)
        => id.Value;

    public static implicit operator OrderId(Guid id)
        => new(id);
}