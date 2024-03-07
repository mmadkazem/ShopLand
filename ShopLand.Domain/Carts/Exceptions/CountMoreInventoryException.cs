namespace ShopLand.Domain.Carts.Exceptions;

public class CountMoreInventoryException : ShopLandBadRequestBaseExceptions
{
    public CountMoreInventoryException()
        : base("count is more than inventory, count not valid.") {}
}