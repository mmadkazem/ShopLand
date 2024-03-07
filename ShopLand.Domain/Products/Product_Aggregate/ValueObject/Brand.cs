namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;


public record Brand
{
    public string Value { get; }
    public Brand(string value)
    {
        if (IsValid(value))
        {
            throw new BrandInvalidException();
        }
        Value = value.Trim().ToUpper();
    }

    private bool IsValid(string value)
    => string.IsNullOrWhiteSpace(value) &&
        StringUtil.IsValidLength(value, 5, 15);

    public static implicit operator string(Brand brand)
        => brand.Value;

    public static implicit operator Brand(string brand)
        => new(brand);
}