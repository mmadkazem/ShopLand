namespace ShopLand.Domain.Products.Category_Aggregate.Entities;

public class Category : BaseEntity<CategoryId>, IAggregateRoot
{
    public CategoryName CategoryName { get; private set; }
    internal Category(CategoryId id, CategoryName categoryName)
        : base(id)
    {
        CategoryName = categoryName;
    }
    public Category() : base(Guid.NewGuid()){}

    public void UpdateCategoryName(CategoryName categoryName)
    {
        CategoryName = categoryName;
    }
}