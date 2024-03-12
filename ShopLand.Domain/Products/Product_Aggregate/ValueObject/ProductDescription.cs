namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;

public record ProductDescription
{
    public string Value { get; }
    public ProductDescription(string value)
    {
        if (!IsValid(value))
        {
            throw new ProductDescriptionInvalidException();
        }
        Value = value.Trim().ToUpper();
    }

    private bool IsValid(string value)
        => string.IsNullOrWhiteSpace(value) &&
            StringUtil.IsValidLength(value, 10, 100);

    public static implicit operator string(ProductDescription brand)
        => brand.Value;

    public static implicit operator ProductDescription(string brand)
        => new(brand);
}