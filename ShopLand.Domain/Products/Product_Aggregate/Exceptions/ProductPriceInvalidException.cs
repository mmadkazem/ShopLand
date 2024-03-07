namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;


public class ProductPriceInvalidException : ShopLandBadRequestBaseExceptions
{
    public ProductPriceInvalidException()
        : base("This product price not valid.") {}
}