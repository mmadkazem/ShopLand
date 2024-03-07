namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;

public class ProductNameInvalidException : ShopLandBadRequestBaseExceptions
{
    public ProductNameInvalidException()
        : base("This product name not valid.") {}
}