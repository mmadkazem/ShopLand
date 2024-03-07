namespace ShopLand.Domain.Products.Category_Aggregate.Factories;

public class CategoryFactory : ICategoryFactory
{
    public Category Create(CategoryName categoryName)
        => new(Guid.NewGuid(), categoryName);
}