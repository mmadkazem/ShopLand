namespace ShopLand.Domain.Products.Product_Aggregate.ValueObject;

public record ProductCategory
{
    public ProductCategory(ProductId productId, Guid category)
    {
        ProductId = productId;
        Category = category;
    }
    public ProductId ProductId { get; }
    public Guid Category { get; }
}