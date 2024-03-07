namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;


public class ProductIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public ProductIdEmptyException()
       : base("Product ID cannot be empty.") {}
}