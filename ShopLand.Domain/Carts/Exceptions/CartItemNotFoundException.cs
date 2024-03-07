namespace ShopLand.Domain.Carts.Exceptions;

class CartItemNotFoundException : ShopLandBadRequestBaseExceptions
{
    public CartItemNotFoundException()
        : base("No cart item found with this information")
    {
    }
}