namespace ShopLand.Domain.Carts.ValueObject;

public record CartId : ID
{
    public Guid Value { get; }

    public CartId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new CartIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(CartId id)
        => id.Value;

    public static implicit operator CartId(Guid id)
        => new(id);
}