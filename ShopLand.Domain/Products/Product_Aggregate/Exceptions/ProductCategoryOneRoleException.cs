namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;

class ProductCategoryOneRoleException : ShopLandBadRequestBaseExceptions
{
    public ProductCategoryOneRoleException()
        : base("It has a category, it cannot be deleted.") {}
}