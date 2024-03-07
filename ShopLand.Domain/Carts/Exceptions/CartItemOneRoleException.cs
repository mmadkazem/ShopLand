namespace ShopLand.Domain.Carts.Exceptions;

public class CartItemOneRoleException : ShopLandBadRequestBaseExceptions
{
    public CartItemOneRoleException()
        : base("It has a cart item, it cannot be deleted."){}
}