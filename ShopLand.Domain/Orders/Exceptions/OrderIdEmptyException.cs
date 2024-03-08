namespace ShopLand.Domain.Orders.Exceptions;

public class OrderIdEmptyException : ShopLandBadRequestBaseExceptions
{
    public OrderIdEmptyException()
        : base(""){}
}