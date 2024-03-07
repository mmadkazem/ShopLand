namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;

public record ProductPrice
{
    public uint Value { get; }

    public ProductPrice(uint value)
    {
        if (value < 10_000)
        {
            throw new ProductPriceInvalidException();
        }
        Value = value;
    }

    public static implicit operator uint(ProductPrice price)
        => price.Value;

    public static implicit operator ProductPrice(uint price)
        => new(price);
}