namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;

public record ProductId : ID
{
    public Guid Value { get; }

    public ProductId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ProductIdEmptyException();
        }
        Value = value;
    }

    public static implicit operator Guid(ProductId id)
        => id.Value;

    public static implicit operator ProductId(Guid id)
        => new(id);
}