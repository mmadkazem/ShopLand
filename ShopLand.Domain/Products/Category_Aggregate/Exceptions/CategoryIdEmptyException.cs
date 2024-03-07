namespace ShopLand.Domain.Products.Category_Aggregate.Exceptions;


public class CategoryIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public CategoryIdEmptyException()
        : base("Category ID cannot be empty.")
    {
    }
}