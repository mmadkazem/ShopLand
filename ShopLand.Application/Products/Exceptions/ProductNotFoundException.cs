namespace ShopLand.Application.Products.Exceptions;


public class ProductNotFoundException : ShopLandNotFoundBaseExceptions
{
    public ProductNotFoundException()
        : base("No product found with this information")
    {
    }
}