namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;


public class BrandInvalidException : ShopLandBadRequestBaseExceptions
{
    public BrandInvalidException()
        : base("This brand not valid.") {}
}