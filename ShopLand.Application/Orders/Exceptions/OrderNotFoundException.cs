namespace ShopLand.Application.Orders.Exceptions;

public class OrderNotFoundException : ShopLandNotFoundBaseExceptions
{
    public OrderNotFoundException()
        : base("No order found with this information"){}
}