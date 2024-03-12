namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;

public class ProductCategoryOneRoleException : ShopLandBadRequestBaseExceptions
{
    public ProductCategoryOneRoleException()
        : base("It has a category, it cannot be deleted.") {}
}