namespace ShopLand.Domain.Products.Product_Aggregate.Exceptions;

public class InventoryInValidException : ShopLandBadRequestBaseExceptions
{
    public InventoryInValidException()
        : base("this inventory value not valid.") {}
}