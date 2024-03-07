namespace ShopLand.Application.Products.Exceptions;


public class CategoryNotFoundException : ShopLandNotFoundBaseExceptions
{
    public CategoryNotFoundException()
        : base("No category found with this information") {}
}