namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;


public record ProductName
{
    public string Value { get; }

    public ProductName(string value)
    {
        if (!IsValid(value))
        {
            throw new ProductNameInvalidException();
        }
        Value = value.Trim().ToUpper();
    }

    private bool IsValid(string value)
        => string.IsNullOrWhiteSpace(value) &&
            StringUtil.IsValidLength(value, 5, 50);


    public static implicit operator string(ProductName productName)
        => productName.Value;

    public static implicit operator ProductName(string productName)
        => new(productName);
}