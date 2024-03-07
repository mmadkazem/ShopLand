namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;

public class ProductCategoryAlreadyExistsException
    : ShopLandBadRequestBaseExceptions
{
    public ProductCategoryAlreadyExistsException()
        : base("This category already exists Before.") {}
}