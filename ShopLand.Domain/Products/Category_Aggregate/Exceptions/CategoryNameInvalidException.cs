namespace ShopLand.Domain.Products.Category_Aggregate.Exceptions;

public class CategoryNameInvalidException : ShopLandBadRequestBaseExceptions
{
    public CategoryNameInvalidException()
        : base("This category name not valid.") {}
}