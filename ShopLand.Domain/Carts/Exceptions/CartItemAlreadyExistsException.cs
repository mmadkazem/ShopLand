namespace ShopLand.Domain.Carts.Exceptions;

public class CartItemAlreadyExistsException : ShopLandBadRequestBaseExceptions
{
    public CartItemAlreadyExistsException()
        : base("This cart item already exists Before.") {}
}