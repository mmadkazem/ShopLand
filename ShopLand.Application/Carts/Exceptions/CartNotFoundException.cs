namespace ShopLand.Application.Carts.Exceptions;

public class CartNotFoundException : ShopLandNotFoundBaseExceptions
{
    public CartNotFoundException()
        : base("No cart found with this information"){}
}