namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;


public class ProductDescriptionInvalidException : ShopLandBadRequestBaseExceptions
{
    public ProductDescriptionInvalidException()
        : base("This product Description not valid.") {}
}