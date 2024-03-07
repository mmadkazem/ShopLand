namespace ShopLand.Domain.Carts.Exceptions;

public class CartIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public CartIdEmptyException()
        : base("Cart ID cannot be empty.") {}
}