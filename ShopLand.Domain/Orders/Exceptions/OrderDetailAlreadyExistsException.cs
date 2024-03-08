namespace ShopLand.Domain.Orders.Exceptions;

public class OrderDetailAlreadyExistsException : ShopLandBadRequestBaseExceptions
{
    public OrderDetailAlreadyExistsException()
        : base("This Order detail already exists Before."){}
}