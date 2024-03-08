namespace ShopLand.Domain.Finances.ValueObject;

public record RequestPayId : ID
{
    public Guid Value { get; }

    public RequestPayId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new RequestPayIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(RequestPayId id)
        => id.Value;

    public static implicit operator RequestPayId(Guid id)
        => new(id);
}