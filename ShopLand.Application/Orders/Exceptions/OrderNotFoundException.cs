namespace ShopLand.Application.Orders.Exceptions;

class OrderNotFoundException : ShopLandNotFoundBaseExceptions
{
    public OrderNotFoundException()
        : base("No order found with this information"){}
}