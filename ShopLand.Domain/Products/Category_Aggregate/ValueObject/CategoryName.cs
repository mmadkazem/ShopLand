namespace ShopLand.Domain.Products.Category_Aggregate.ValueObject;

public record CategoryName
{
    public string Value { get; }

    public CategoryName(string value)
    {
        if (IsValid(value))
        {
            throw new CategoryNameInvalidException();
        }
        Value = value.Trim().ToUpper();
    }

    private bool IsValid(string value)
        => string.IsNullOrWhiteSpace(value) &&
            StringUtil.IsValidLength(value, 10, 100);


    public static implicit operator string(CategoryName productName)
        => productName.Value;

    public static implicit operator CategoryName(string productName)
        => new(productName);
}