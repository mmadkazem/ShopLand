namespace ShopLand.Domain.Products.Category_Aggregate.ValueObject;


public record CategoryId : ID
{
    public Guid Value { get; }

    public CategoryId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new CategoryIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(CategoryId id)
        => id.Value;

    public static implicit operator CategoryId(Guid id)
        => new(id);
}