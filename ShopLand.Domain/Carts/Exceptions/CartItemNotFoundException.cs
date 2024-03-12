namespace ShopLand.Domain.Carts.Exceptions;

public class CartItemNotFoundException : ShopLandBadRequestBaseExceptions
{
    public CartItemNotFoundException()
        : base("No cart item found with this information")
    {
    }
}