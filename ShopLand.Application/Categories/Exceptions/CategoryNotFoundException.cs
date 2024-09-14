namespace ShopLand.Application.Categories.Exceptions;


public class CategoryNotFoundException : ShopLandNotFoundBaseExceptions
{
    public CategoryNotFoundException()
        : base("No category found with this information") { }
}