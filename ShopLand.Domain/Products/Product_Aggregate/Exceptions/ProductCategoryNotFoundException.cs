namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;

public class ProductCategoryNotFoundException : ShopLandBadRequestBaseExceptions
{
    public ProductCategoryNotFoundException()
        : base("This Category not found."){}
}