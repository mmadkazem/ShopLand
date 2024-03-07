namespace ShopLand.Domain.Products.Category_Aggregate.Factories;

public interface ICategoryFactory
{
    Category Create
    (
        CategoryName categoryName
    );
}
